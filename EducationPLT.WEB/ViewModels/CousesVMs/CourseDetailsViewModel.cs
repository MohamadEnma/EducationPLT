using EducationPLT.DAL.Models.CourseEntities;
using System.ComponentModel.DataAnnotations;

namespace EducationPLT.WEB.ViewModels.CousesVMs
{
    /// <summary>
    /// ViewModel for detailed course view
    /// </summary>
    public class CourseDetailsViewModel
    {
        public int CourseId { get; set; }

        [Display(Name = "Course Title")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Status")]
        public CourseStatus Status { get; set; }

        [Display(Name = "Difficulty Level")]
        public CourseDifficulty Difficulty { get; set; }

        [Display(Name = "Published")]
        public bool IsPublished { get; set; }

        [Display(Name = "Created")]
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Last Modified")]
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}")]
        public DateTime LastModifiedAt { get; set; }

        [Display(Name = "Published Date")]
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}")]
        public DateTime? PublishedAt { get; set; }

        [Display(Name = "Course Period")]
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}")]
        public DateTime? StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Maximum Students")]
        public int MaxStudents { get; set; }

        [Display(Name = "Estimated Duration")]
        public int? EstimatedDuration { get; set; }

        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? Price { get; set; }

        [Display(Name = "Free Course")]
        public bool IsFree { get; set; }

        [Display(Name = "Instructor")]
        public string InstructorName { get; set; } = string.Empty;

        public string InstructorId { get; set; } = string.Empty;

        [Display(Name = "Category")]
        public string CategoryName { get; set; } = string.Empty;

        public int? CategoryId { get; set; }

        [Display(Name = "Course Thumbnail")]
        public string ThumbnailUrl { get; set; } = string.Empty;

        [Display(Name = "Preview Video")]
        public string PreviewVideoUrl { get; set; } = string.Empty;

        [Display(Name = "Prerequisites & Requirements")]
        public string Requirements { get; set; } = string.Empty;

        [Display(Name = "What You'll Learn")]
        public string LearningObjectives { get; set; } = string.Empty;

        [Display(Name = "Enrolled Students")]
        public int EnrolledStudentsCount { get; set; }

        [Display(Name = "Available Spots")]
        public int AvailableSpots => MaxStudents - EnrolledStudentsCount;

        public bool IsEnrollmentOpen => AvailableSpots > 0 && IsPublished && Status == CourseStatus.Active;

        // User-specific properties
        public bool IsCurrentUserEnrolled { get; set; }
        public bool CanCurrentUserEdit { get; set; }
        public bool CanCurrentUserEnroll { get; set; }

        public string CreatedBy { get; set; } = string.Empty;
        public string ModifiedBy { get; set; } = string.Empty;
    }
}
