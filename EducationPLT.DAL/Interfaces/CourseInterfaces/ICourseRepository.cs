using EducationPLT.DAL.Models.CourseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPLT.DAL.Interfaces.CourseInterfaces
{
    public interface ICourseRepository
    {
        // Define methods for course repository
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(int courseId);
        Task AddCourseAsync(Course course);
        Task UpdateCourseAsync(Course course);
        Task<bool> DeleteCourseAsync(int courseId);
        Task<Course?> GetCourseWithDetailsAsync(int courseId);
        Task<IEnumerable<Course>> FindCoursesAsync(Func<Course, bool> predicate);



        // Search and Filter Methods
        Task<IEnumerable<Course>> GetCoursesByInstructorAsync(string instructorId);
        Task<IEnumerable<Course>> GetPublishedCoursesAsync();
        Task<IEnumerable<Course>> GetCoursesByCategoryAsync(int categoryId);
        Task<IEnumerable<Course>> GetCoursesByStatusAsync(CourseStatus status);
        Task<IEnumerable<Course>> GetCoursesByDifficultyAsync(CourseDifficulty difficulty);
        Task<IEnumerable<Course>> GetCoursesByTitleAsync(string title);
        Task<IEnumerable<Course>> GetCoursesByKeywordAsync(string keyword);
        Task<IEnumerable<Course>> GetCoursesByEnrollmentCountAsync(int minEnrollments);
        Task<IEnumerable<Course>> GetCoursesByCreationDateAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Course>> GetCoursesByLastModifiedDateAsync(DateTime startDate, DateTime endDate);

        Task<int> SaveChangesAsync();
    }
}
