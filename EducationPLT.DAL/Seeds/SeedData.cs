
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EducationPLT.DAL.Models.CourseEntities;
using EducationPLT.DAL.Models.UserEntities;
using EducationPLT.DAL.Data;

namespace EducationPlatform.DAL.Seeds
{
    public static class SeedData
    {
        public static async Task SeedAsync(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            // Ensure database is created
            await context.Database.EnsureCreatedAsync();

            await SeedRolesAsync(roleManager); 
            await SeedCourseCategoriesAsync(context);
            await SeedUsersAsync(userManager);
            await SeedCoursesAsync(context, userManager);

            await context.SaveChangesAsync();
        }

        private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin", "Teacher", "Student" };

            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

       private static async Task SeedCourseCategoriesAsync(ApplicationDbContext context)
        {
            if (!context.Categories.Any())
            {
                var categories = new List<CourseCategory>
                {

                    new CourseCategory
                    {
                       
                      Name = "Design",
                      Description = "Graphic design, UI/UX, and creative arts courses",
                      DisplayOrder = 2,
                      IsActive = true,
                      IconUrl = "fas fa-paint-brush",
                      ImageUrl = "/images/categories/design.jpg",
                      ColorCode = "#28a745",
                      Slug = "design",
                      MetaTitle = "Design Courses",
                      MetaDescription = "Unleash your creativity with our design courses",
                      Keywords = "design, graphics, ui, ux, creative",
                      CreatedUtc = DateTime.UtcNow,
                      CreatedBy = "System",
                      LastModifiedAt = DateTime.UtcNow,
                      IsDeleted = false,
                      DeletedAt = null,
                      DeletedBy = null
                    },
                   new CourseCategory
                    {
                       
                        Name = "Business",
                        Description = "Business management, marketing, and entrepreneurship",
                        DisplayOrder = 3,
                        IconUrl = "fas fa-briefcase",
                        ImageUrl = "/images/categories/business.jpg",
                        ColorCode = "#ffc107",
                        IsActive = true,
                        Slug = "business",
                        MetaTitle = "Business Courses",
                        MetaDescription = "Grow your business skills with expert-led courses",
                        Keywords = "business, management, marketing, entrepreneurship",
                        CreatedUtc = DateTime.UtcNow,
                        CreatedBy = "System",
                        LastModifiedAt = DateTime.UtcNow,
                        IsDeleted = false,
                        DeletedAt = null,
                        DeletedBy = null,
                    }

                };
                context.Categories.AddRange(categories);
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager)
        {
            // Admin User
            if (await userManager.FindByEmailAsync("admin@educationplatform.com") == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin@educationplatform.com",
                    Email = "admin@educationplatform.com",
                    EmailConfirmed = true,
                    FirstName = "System",
                    LastName = "Administrator",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    PhoneNumber = "+1234567890",
                    Address = "123 Admin Street, Admin City",
                    Bio = "System Administrator for Education Platform",
                    ProfilePictureUrl = "/images/profiles/admin.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    LastLoginAt = DateTime.UtcNow,
                    AvatarUrl = "/images/avatars/admin-avatar.jpg",
                    CreatedBy = "SYSTEM",
                    DisplayName = "System Admin",
                    ModifiedBy = "SYSTEM"
                };

                var result = await userManager.CreateAsync(adminUser, "Admin123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // Teacher User
            if (await userManager.FindByEmailAsync("teacher@educationplatform.com") == null)
            {
                var teacherUser = new ApplicationUser
                {
                    UserName = "teacher@educationplatform.com",
                    Email = "teacher@educationplatform.com",
                    EmailConfirmed = true,
                    FirstName = "John",
                    LastName = "Smith",
                    DateOfBirth = new DateTime(1985, 5, 15),
                    PhoneNumber = "+1234567891",
                    Address = "456 Teacher Lane, Education City",
                    Bio = "Experienced programming instructor with 10+ years in software development",
                    ProfilePictureUrl = "/images/profiles/teacher.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    LastLoginAt = DateTime.UtcNow,
                    AvatarUrl = "/images/avatars/Teacher-avatar.jpg",
                    CreatedBy = "SYSTEM",
                    DisplayName = "System Teacher",
                    ModifiedBy = "SYSTEM"


                };

                var result = await userManager.CreateAsync(teacherUser, "Teacher123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(teacherUser, "Teacher");
                }
            }

            // Student User
            if (await userManager.FindByEmailAsync("student@educationplatform.com") == null)
            {
                var studentUser = new ApplicationUser
                {
                    UserName = "student@educationplatform.com",
                    Email = "student@educationplatform.com",
                    EmailConfirmed = true,
                    FirstName = "Jane",
                    LastName = "Doe",
                    DateOfBirth = new DateTime(1995, 8, 20),
                    PhoneNumber = "+1234567892",
                    Address = "789 Student Ave, Learning City",
                    Bio = "Passionate learner interested in technology and programming",
                    ProfilePictureUrl = "/images/profiles/student.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    LastLoginAt = DateTime.UtcNow,
                    AvatarUrl = "/images/avatars/Student-avatar.jpg",
                    CreatedBy = "SYSTEM",
                    DisplayName = "System Student",
                    ModifiedBy = "SYSTEM"
                };

                var result = await userManager.CreateAsync(studentUser, "Student123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(studentUser, "Student");
                }
            }
        }

        private static async Task SeedCoursesAsync(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            if (!context.Courses.Any())
            {
                var teacher = await userManager.FindByEmailAsync("teacher@educationplatform.com");
                var categories = await context.Categories.ToListAsync();

                if (teacher != null && categories.Any())
                {
                    var programmingCategory = categories.FirstOrDefault(c => c.Name == "Programming");
                    if (programmingCategory == null)
                    {
                        throw new Exception("Programming category not found. Please ensure categories are seeded before courses.");
                    }else
                    {
                        programmingCategory.IsActive = true;
                        programmingCategory.LastModifiedAt = DateTime.UtcNow;
                        context.Categories.Update(programmingCategory);
                    }

                    var designCategory = categories.FirstOrDefault(c => c.Name == "Design");
                    if (designCategory == null)
                    {
                        throw new Exception("Programming category not found. Please ensure categories are seeded before courses.");
                    }
                    else
                    {
                        designCategory.IsActive = true;
                        designCategory.LastModifiedAt = DateTime.UtcNow;
                        context.Categories.Update(designCategory);
                    }
                    var businessCategory = categories.FirstOrDefault(c => c.Name == "Programming");
                    if (businessCategory == null)
                    {
                        throw new Exception("Programming category not found. Please ensure categories are seeded before courses.");
                    }
                    else
                    {
                        businessCategory.IsActive = true;
                        businessCategory.LastModifiedAt = DateTime.UtcNow;
                        context.Categories.Update(businessCategory);
                    }
                    var courses = new List<Course>
                    {
                        new Course
                        {

                            Title = "C# Programming Fundamentals",
                            Description = "Learn the basics of C# programming language from scratch. This comprehensive course covers variables, data types, control structures, object-oriented programming, and more.",
                            IsPublished = true,
                            Status = CourseStatus.Active,
                            Difficulty = CourseDifficulty.Beginner,
                            Price =  194,
                            IsFree = false,
                            InstructorId = teacher.Id,
                            CategoryId = programmingCategory.CourseCategoryId,
                            StartDate = DateTime.UtcNow.AddDays(7),
                            EndDate = DateTime.UtcNow.AddDays(67),
                            EstimatedDuration = 1800,
                            ThumbnailUrl = "/images/courses/csharp-fundamentals.jpg",
                            PreviewVideoUrl = "/videos/previews/csharp-fundamentals.mp4",
                            Requirements = "Basic computer skills, No prior programming experience required",
                            LearningObjectives = "Understand C# syntax, Create console applications, Apply OOP concepts, Debug programs effectively",
                            CreatedAt = DateTime.UtcNow,
                            LastModifiedAt = DateTime.UtcNow,
                            PublishedAt = DateTime.UtcNow,
                            CreatedUtc = DateTime.UtcNow,
                            CreatedBy = "System",
                            IsDeleted = false
                        },
                        new Course
                        {
                            Title = "UI/UX Design Principles",
                            Description = "Master the art of user interface and user experience design. Learn design thinking, wireframing, prototyping, and industry-standard tools.",
                            IsPublished = true,
                            Status = CourseStatus.Active,
                            Difficulty = CourseDifficulty.Intermediate,
                            Price = 149.99m,
                            IsFree = false,
                            InstructorId = teacher.Id,
                            CategoryId = designCategory.CourseCategoryId,
                            StartDate = DateTime.UtcNow.AddDays(14),
                            EndDate = DateTime.UtcNow.AddDays(84),
                            EstimatedDuration = 2000,
                            ThumbnailUrl = "/images/courses/uiux-design.jpg",
                            PreviewVideoUrl = "/videos/previews/uiux-design.mp4",
                            Requirements = "Basic design knowledge helpful but not required, Access to design software (Figma/Adobe XD)",
                            LearningObjectives = "Create user-centered designs, Build interactive prototypes, Conduct user research, Apply design systems",
                            CreatedAt = DateTime.UtcNow,
                            LastModifiedAt = DateTime.UtcNow,
                            PublishedAt = DateTime.UtcNow,
                            CreatedUtc = DateTime.UtcNow,
                            CreatedBy = "System",
                            IsDeleted = false
                        },
                        new Course
                        {
                            Title = "Digital Marketing Strategies",
                            Description = "Comprehensive guide to modern digital marketing. Learn SEO, social media marketing, content marketing, email campaigns, and analytics.",
                            IsPublished = true,
                            Status = CourseStatus.Active,
                            Difficulty = CourseDifficulty.Beginner,
                            Price = 0m,
                            IsFree = true,
                            InstructorId = teacher.Id,
                            CategoryId = businessCategory.CourseCategoryId,
                            StartDate = DateTime.UtcNow.AddDays(21),
                            EndDate = DateTime.UtcNow.AddDays(63),
                            EstimatedDuration = 2500,
                            ThumbnailUrl = "/images/courses/digital-marketing.jpg",
                            PreviewVideoUrl = "/videos/previews/digital-marketing.mp4",
                            Requirements = "Basic internet usage, Email account, Social media familiarity",
                            LearningObjectives = "Develop marketing strategies, Optimize for search engines, Create engaging content, Analyze campaign performance",
                            CreatedAt = DateTime.UtcNow,
                            LastModifiedAt = DateTime.UtcNow,
                            PublishedAt = DateTime.UtcNow,
                            CreatedUtc = DateTime.UtcNow,
                            CreatedBy = "System",
                            IsDeleted = false
                        }
                    };

                    context.Courses.AddRange(courses);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}