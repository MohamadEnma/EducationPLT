using EducationPLT.DAL.Models.CourseEntities;
using System.ComponentModel.DataAnnotations;

namespace EducationPLT.WEB.ViewModels.CousesVMs
{
    /// <summary>
    /// ViewModel for displaying courses in lists/tables with pagination
    /// </summary>
    public class CourseListViewModel
    {
        public List<CourseListItemViewModel> Courses { get; set; } = new();

        // Pagination properties
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public int TotalCourses { get; set; }
        public int PageSize { get; set; } = 10;

        // Filter properties
        public string SearchTerm { get; set; } = string.Empty;
        public CourseStatus? StatusFilter { get; set; }
        public CourseDifficulty? DifficultyFilter { get; set; }
        public bool? IsPublishedFilter { get; set; }
        public bool? IsFreeFilter { get; set; }
        public int? CategoryFilter { get; set; }
        public string InstructorFilter { get; set; } = string.Empty;

        // Sorting
        public string SortBy { get; set; } = "CreatedAt";
        public string SortDirection { get; set; } = "desc";

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
    }

    /// <summary>
    /// Individual course item for list display
    /// </summary>
    public class CourseListItemViewModel
    {
        public int CourseId { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Description")]
        public string ShortDescription { get; set; } = string.Empty;

        [Display(Name = "Instructor")]
        public string InstructorName { get; set; } = string.Empty;

        [Display(Name = "Status")]
        public CourseStatus Status { get; set; }

        [Display(Name = "Difficulty")]
        public CourseDifficulty Difficulty { get; set; }

        [Display(Name = "Published")]
        public bool IsPublished { get; set; }

        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? Price { get; set; }

        [Display(Name = "Free")]
        public bool IsFree { get; set; }

        [Display(Name = "Students")]
        public int EnrolledCount { get; set; }

        [Display(Name = "Max Students")]
        public int MaxStudents { get; set; }

        [Display(Name = "Duration")]
        public int? EstimatedDuration { get; set; }

        [Display(Name = "Created")]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Modified")]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime LastModifiedAt { get; set; }

        public string ThumbnailUrl { get; set; } = string.Empty;

        public string InstructorId { get; set; } = string.Empty;
    }
}
