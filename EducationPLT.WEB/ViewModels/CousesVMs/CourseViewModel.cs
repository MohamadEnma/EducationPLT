using EducationPLT.DAL.Models.CourseEntities;
using System.ComponentModel.DataAnnotations;

namespace EducationPLT.WEB.ViewModels.CousesVMs
{
    public class CourseViewModel
    {
        public int CourseId { get; set; }

        [Display(Name = "Course Title")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Published")]
        public bool IsPublished { get; set; }

        [Display(Name = "Status")]
        public CourseStatus Status { get; set; }

        [Display(Name = "Difficulty Level")]
        public CourseDifficulty Difficulty { get; set; }

        [Display(Name = "Created At")]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Last Modified")]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime LastModifiedAt { get; set; }

        [Display(Name = "Published Date")]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime? PublishedAt { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Maximum Students")]
        public int MaxStudents { get; set; }

        [Display(Name = "Estimated Duration (minutes)")]
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
        public int? CategoryId { get; set; }

        [Display(Name = "Thumbnail")]
        public string ThumbnailUrl { get; set; } = string.Empty;

        [Display(Name = "Preview Video")]
        public string PreviewVideoUrl { get; set; } = string.Empty;

        [Display(Name = "Requirements")]
        public string Requirements { get; set; } = string.Empty;

        [Display(Name = "Learning Objectives")]
        public string LearningObjectives { get; set; } = string.Empty;

        [Display(Name = "Enrolled Students")]
        public int EnrolledStudentsCount { get; set; }

        public string CreatedBy { get; set; } = string.Empty;
        public string ModifiedBy { get; set; } = string.Empty;
    }
}

