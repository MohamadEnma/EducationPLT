using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EducationPLT.DAL.Data;
using EducationPLT.DAL.Models.CourseEntities;
using EducationPLT.WEB.ViewModels.CousesVMs;
using EducationPLT.DAL.Models.UserEntities;
using Microsoft.AspNetCore.Identity;

namespace EducationPLT.WEB.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CoursesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index(CourseListViewModel vm)
        {
            // Build the query starting with all courses
            var query = _context.Courses
                .Include(c => c.Instructor)
                .Include(c => c.Category)
                .Include(c => c.Enrollments)
                .AsQueryable();
            // Apply search filter
            if(!string.IsNullOrEmpty(vm.SearchTerm))
            {
                query = query.Where(c => c.Title.Contains(vm.SearchTerm) || c.Description.Contains(vm.SearchTerm));
            }
            // Apply status filter
            if (vm.StatusFilter.HasValue)
            {
                query = query.Where(c => c.Status == vm.StatusFilter.Value);
            }
            // Apply difficulty filter
            if (vm.DifficultyFilter.HasValue)
            {
                query = query.Where(c => c.Difficulty == vm.DifficultyFilter.Value);
            }
            // Apply free/paid filter
            if (vm.IsFreeFilter.HasValue)
            {
                query = query.Where(c => c.IsFree == vm.IsFreeFilter.Value);
            }

            // Apply category filter
            if (vm.CategoryFilter.HasValue)
            {
                query = query.Where(c => c.CategoryId == vm.CategoryFilter.Value);
            }

            query = vm.SortDirection.ToLower() switch
            {
                "title" => vm.SortDirection == "asc" ?
                    query.OrderBy(c => c.Title) :
                    query.OrderByDescending(c => c.Title),
                "instructor" => vm.SortDirection == "asc" ?
                    query.OrderBy(c => c.Instructor.UserName) :
                    query.OrderByDescending(c => c.Instructor.UserName),
                "status" => vm.SortDirection == "asc" ?
                    query.OrderBy(c => c.Status) :
                    query.OrderByDescending(c => c.Status),
                "difficulty" => vm.SortDirection == "asc" ?
                    query.OrderBy(c => c.Difficulty) :
                    query.OrderByDescending(c => c.Difficulty),
                "price" => vm.SortDirection == "asc" ?
                    query.OrderBy(c => c.Price) :
                    query.OrderByDescending(c => c.Price),
                "enrollments" => vm.SortDirection == "asc" ?
                    query.OrderBy(c => c.Enrollments.Count) :
                    query.OrderByDescending(c => c.Enrollments.Count),
                "lastmodified" => vm.SortDirection == "asc" ?
                    query.OrderBy(c => c.LastModifiedAt) :
                    query.OrderByDescending(c => c.LastModifiedAt),
                _ => vm.SortDirection == "asc" ?
                    query.OrderBy(c => c.CreatedAt) :
                    query.OrderByDescending(c => c.CreatedAt)
            };

            // Get total count for pagination
            vm.TotalCourses = await query.CountAsync();
            vm.TotalPages = (int)Math.Ceiling((double)vm.TotalCourses / vm.PageSize);

            // Apply pagination
            var courses = await query
                .Skip((vm.CurrentPage - 1) * vm.PageSize)
                .Take(vm.PageSize)
                .Select(c => new CourseListItemViewModel
                {
                    CourseId = c.CourseId,
                    Title = c.Title,
                    ShortDescription = c.Description.Length > 100 ?
                        c.Description.Substring(0, 100) + "..." : c.Description,
                    InstructorName = c.Instructor.UserName ?? "Unknown",
                    InstructorId = c.InstructorId,
                    Status = c.Status,
                    Difficulty = c.Difficulty,
                    IsPublished = c.IsPublished,
                    Price = c.Price,
                    IsFree = c.IsFree,
                    EnrolledCount = c.Enrollments.Count(e => e.IsActive),
                    MaxStudents = c.MaxStudents,
                    EstimatedDuration = c.EstimatedDuration,
                    CreatedAt = c.CreatedAt,
                    LastModifiedAt = c.LastModifiedAt,
                    ThumbnailUrl = c.ThumbnailUrl
                })
                .ToListAsync();

            // Populate the view model
            vm.Courses = courses;

            return View(vm);

        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new CreateCourseViewModel();

            // Populate dropdown lists
            viewModel.DifficultyOptions = new SelectList(Enum.GetValues(typeof(CourseDifficulty))
                .Cast<CourseDifficulty>()
                .Select(d => new { Value = (int)d, Text = d.ToString() }), "Value", "Text");

            viewModel.CategoryOptions = new SelectList(_context.Categories
                .Where(c => c.IsActive && !c.IsDeleted)
                .OrderBy(c => c.DisplayOrder)
                .ThenBy(c => c.Name), "CourseCategoryId", "Name");

            // Get users who can be instructors
            var instructors = await _userManager.GetUsersInRoleAsync("Teacher");
            var admins = await _userManager.GetUsersInRoleAsync("Admin");
            var allInstructors = instructors.Concat(admins)
                .Where(u => u.IsActive && !u.IsDeleted)
                .Select(u => new {
                    Id = u.Id,
                    FullName = u.FullName + " (" + u.Email + ")"
                })
                .OrderBy(u => u.FullName)
                .ToList();

            viewModel.InstructorOptions = new SelectList(allInstructors, "Id", "FullName");



            return View(viewModel);
        }

        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCourseViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Create new course entity
                    var course = new Course
                    {
                        InstructorId = viewModel.InstructorId ?? User.Identity.Name ?? "System", // Set current user as instructor
                        Title = viewModel.Title,
                        Description = viewModel.Description,
                        Difficulty = viewModel.Difficulty,
                        StartDate = viewModel.StartDate,
                        EndDate = viewModel.EndDate,
                        MaxStudents = viewModel.MaxStudents,
                        EstimatedDuration = viewModel.EstimatedDuration,
                        Price = viewModel.Price,
                        IsFree = viewModel.IsFree,
                        CategoryId = viewModel.CategoryId,
                        Requirements = viewModel.Requirements,
                        LearningObjectives = viewModel.LearningObjectives,

                        // Set default values
                        IsPublished = false,
                        Status = CourseStatus.Draft,
                        CreatedAt = DateTime.UtcNow,
                        LastModifiedAt = DateTime.UtcNow,
                        CreatedUtc = DateTime.UtcNow,
                        CreatedBy = "System", // Current user
                        IsDeleted = false

                    };

                    // Handle file uploads
                    if (viewModel.ThumbnailFile != null && viewModel.ThumbnailFile.Length > 0)
                    {
                        course.ThumbnailUrl = await SaveFileAsync(viewModel.ThumbnailFile, "thumbnails");
                    }

                    if (viewModel.PreviewVideoFile != null && viewModel.PreviewVideoFile.Length > 0)
                    {
                        course.PreviewVideoUrl = await SaveFileAsync(viewModel.PreviewVideoFile, "videos");
                    }

                    // Validate business rules
                    if (course.EndDate.HasValue && course.StartDate.HasValue && course.EndDate < course.StartDate)
                    {
                        ModelState.AddModelError("EndDate", "End date cannot be earlier than start date.");
                    }

                    if (!course.IsFree && (!course.Price.HasValue || course.Price <= 0))
                    {
                        ModelState.AddModelError("Price", "Price is required for paid courses.");
                    }

                    if (course.IsFree)
                    {
                        course.Price = 0; // Ensure free courses have price set to 0
                    }

                    // Re-validate after business rule checks
                    if (!ModelState.IsValid)
                    {
                        // Repopulate dropdown lists
                        viewModel.DifficultyOptions = new SelectList(Enum.GetValues(typeof(CourseDifficulty))
                            .Cast<CourseDifficulty>()
                            .Select(d => new { Value = (int)d, Text = d.ToString() }), "Value", "Text", viewModel.Difficulty);

                        viewModel.CategoryOptions = new SelectList(_context.Categories
                            .Where(c => c.IsActive && !c.IsDeleted)
                            .OrderBy(c => c.DisplayOrder)
                            .ThenBy(c => c.Name), "CourseCategoryId", "Name", viewModel.CategoryId);

                        return View(viewModel);
                    }

                    _context.Add(course);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Course created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log the exception
                    ModelState.AddModelError("", "An error occurred while creating the course. Please try again.");

                    // Repopulate dropdown lists
                    viewModel.DifficultyOptions = new SelectList(Enum.GetValues(typeof(CourseDifficulty))
                        .Cast<CourseDifficulty>()
                        .Select(d => new { Value = (int)d, Text = d.ToString() }), "Value", "Text", viewModel.Difficulty);

                    viewModel.CategoryOptions = new SelectList(_context.Categories
                        .Where(c => c.IsActive && !c.IsDeleted)
                        .OrderBy(c => c.DisplayOrder)
                        .ThenBy(c => c.Name), "CourseCategoryId", "Name", viewModel.CategoryId);

                    return View(viewModel);
                }
            }

            // If we got this far, something failed, redisplay form
            viewModel.DifficultyOptions = new SelectList(Enum.GetValues(typeof(CourseDifficulty))
                .Cast<CourseDifficulty>()
                .Select(d => new { Value = (int)d, Text = d.ToString() }), "Value", "Text", viewModel.Difficulty);

            viewModel.CategoryOptions = new SelectList(_context.Categories
                .Where(c => c.IsActive && !c.IsDeleted)
                .OrderBy(c => c.DisplayOrder)
                .ThenBy(c => c.Name), "CourseCategoryId", "Name", viewModel.CategoryId);

            return View(viewModel);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["InstructorId"] = new SelectList(_context.Users, "Id", "Id", course.InstructorId);
            return View(course);
        }

        // POST: Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,Title,Description,IsPublished,Status,Difficulty,CreatedAt,LastModifiedAt,PublishedAt,StartDate,EndDate,MaxStudents,EstimatedDuration,Price,IsFree,InstructorId,CategoryId,ThumbnailUrl,PreviewVideoUrl,Requirements,LearningObjectives,CreatedUtc,CreatedBy,ModifiedUtc,ModifiedBy,IsDeleted,DeletedAt,DeletedBy")] Course course)
        {
            if (id != course.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.CourseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstructorId"] = new SelectList(_context.Users, "Id", "Id", course.InstructorId);
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseId == id);
        }





        // Helper method for file upload handling
        private async Task<string> SaveFileAsync(IFormFile file, string subfolder)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return string.Empty;

                // Create uploads directory if it doesn't exist
                var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", subfolder);
                Directory.CreateDirectory(uploadsPath);

                // Generate unique filename
                var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
                var filePath = Path.Combine(uploadsPath, fileName);

                // Save file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Return relative path for storing in database
                return $"/uploads/{subfolder}/{fileName}";
            }
            catch (Exception)
            {
                // Log error and return empty string
                return string.Empty;
            }
        }
    }
}
