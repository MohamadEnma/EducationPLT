using EducationPLT.DAL.Data;
using EducationPLT.DAL.Interfaces.CourseInterfaces;
using EducationPLT.DAL.Models.CourseEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPLT.DAL.Repositories.CourseRepositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context) : base(context)
        {    
        }
        public async Task AddCourseAsync(Course course)
        {
            if(course == null)
            {
                throw new ArgumentNullException(nameof(course), "Course cannot be null");
            }
            await _dbSet.AddAsync(course);
        }

        public async Task<bool> DeleteCourseAsync(int courseId)
        {
            if(courseId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(courseId), "Course ID must be greater than zero.");
            }
            var course = _dbSet.Find(courseId);
            if (course == null)
            {
                throw new KeyNotFoundException($"Course with ID {courseId} not found.");
            }
            course.IsDeleted = true; // Soft delete
            _context.Courses.Update(course);
            return await _context.SaveChangesAsync().ContinueWith(t => t.Result > 0);
        }

        public async Task<IEnumerable<Course>> FindCoursesAsync(Func<Course, bool> predicate)
        {
            // Note: This loads all courses into memory first, then applies the predicate
            // For better performance with large datasets, consider using Expression<Func<Course, bool>>
            var allCourses = await _dbSet
                .Where(c => !c.IsDeleted)
                .Include(c => c.Instructor)
                .ToListAsync();

            return allCourses.Where(predicate);
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _dbSet
                .Where(c => !c.IsDeleted)
                .Include(c => c.Instructor)
                .ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int courseId)
        {
           return await _dbSet
                .Where(c => c.CourseId == courseId && !c.IsDeleted)
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException($"Course with ID {courseId} not found.");
        }

        public async Task<IEnumerable<Course>> GetCoursesByCategoryAsync(int categoryId)
        {
            return await _dbSet
                .Where(c => c.CategoryId == categoryId && !c.IsDeleted)
                .Include(c => c.Instructor)
                .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesByCreationDateAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(c => c.CreatedAt >= startDate && c.CreatedAt <= endDate && !c.IsDeleted)
                .Include(c => c.Instructor)
                .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesByDifficultyAsync(CourseDifficulty difficulty)
        {
           return await _dbSet
                .Where(c => c.Difficulty == difficulty && !c.IsDeleted)
                .Include(c => c.Instructor)
                .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesByEnrollmentCountAsync(int minEnrollments)
        {
            //return await _dbSet
            //    .Where(c => c.EnrollmentCount >= minEnrollments && !c.IsDeleted)
            //    .Include(c => c.Instructor)
            //    .Include(c => c.Category)
            //    .ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Course>> GetCoursesByInstructorAsync(string instructorId)
        {
            return await _dbSet
                .Where(c => c.InstructorId == instructorId && !c.IsDeleted)
                .Include(c => c.Instructor)
                .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesByKeywordAsync(string keyword)
        {
            return await _dbSet
                .Where(c => (c.Title.Contains(keyword) || c.Description.Contains(keyword)) && !c.IsDeleted)
                .Include(c => c.Instructor)
                .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesByLastModifiedDateAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(c => c.ModifiedUtc >= startDate && c.ModifiedUtc <= endDate && !c.IsDeleted)
                .Include(c => c.Instructor)
                .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesByStatusAsync(CourseStatus status)
        {
           return await _dbSet
                .Where(c => c.Status == status && !c.IsDeleted)
                .Include(c => c.Instructor)
                .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesByTitleAsync(string title)
        {
            return await _dbSet
                .Where(c => c.Title.Contains(title) && !c.IsDeleted)
                .Include(c => c.Instructor)
                .ToListAsync();
        }

        public async Task<Course?> GetCourseWithDetailsAsync(int courseId)
        {
            return await _dbSet
                .Where(c => c.CourseId == courseId && !c.IsDeleted)
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Course>> GetPublishedCoursesAsync()
        {
            return await _dbSet
                .Where(c => c.Status == CourseStatus.Active && !c.IsDeleted)
                .Include(c => c.Instructor)
                .ToListAsync();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task UpdateCourseAsync(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
