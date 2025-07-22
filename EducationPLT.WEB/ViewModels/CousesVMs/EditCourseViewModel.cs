using EducationPLT.DAL.Models.CourseEntities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EducationPLT.WEB.ViewModels.CousesVMs
{
    /// <summary>
    /// ViewModel for editing existing courses
    /// </summary>
    public class EditCourseViewModel
    {
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course title is required")]
        [StringLength(100, ErrorMessage = "Course Title cannot exceed 100 characters.")]
        [Display(Name = "Course Title")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course description is required")]
        [StringLength(500, ErrorMessage = "Course Description cannot exceed 500 characters.")]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Published")]
        public bool IsPublished { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Please select a status")]
        public CourseStatus Status { get; set; }

        [Display(Name = "Difficulty Level")]
        [Required(ErrorMessage = "Please select a difficulty level")]
        public CourseDifficulty Difficulty { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Maximum Students")]
        [Range(1, 1000, ErrorMessage = "Maximum students must be between 1 and 1000")]
        public int MaxStudents { get; set; }

        [Display(Name = "Estimated Duration (minutes)")]
        [Range(1, 10080, ErrorMessage = "Duration must be between 1 minute and 1 week")]
        public int? EstimatedDuration { get; set; }

        [Display(Name = "Price")]
        [Range(0, 9999.99, ErrorMessage = "Price must be between 0 and 9999.99")]
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }

        [Display(Name = "Free Course")]
        public bool IsFree { get; set; }

        public string InstructorId { get; set; } = string.Empty;

        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Display(Name = "Current Thumbnail")]
        public string ThumbnailUrl { get; set; } = string.Empty;

        [Display(Name = "New Thumbnail Image")]
        [DataType(DataType.Upload)]
        public IFormFile? ThumbnailFile { get; set; }

        [Display(Name = "Current Preview Video")]
        public string PreviewVideoUrl { get; set; } = string.Empty;

        [Display(Name = "New Preview Video")]
        [DataType(DataType.Upload)]
        public IFormFile? PreviewVideoFile { get; set; }

        [StringLength(4000, ErrorMessage = "Requirements cannot exceed 4000 characters.")]
        [Display(Name = "Requirements")]
        [DataType(DataType.MultilineText)]
        public string Requirements { get; set; } = string.Empty;

        [StringLength(4000, ErrorMessage = "Learning objectives cannot exceed 4000 characters.")]
        [Display(Name = "Learning Objectives")]
        [DataType(DataType.MultilineText)]
        public string LearningObjectives { get; set; } = string.Empty;

        // Dropdown lists for form binding
        public SelectList? StatusOptions { get; set; }
        public SelectList? DifficultyOptions { get; set; }
        public SelectList? CategoryOptions { get; set; }

        // Audit information (read-only)
        [Display(Name = "Created")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Last Modified")]
        public DateTime LastModifiedAt { get; set; }

        public string CreatedBy { get; set; } = string.Empty;
    }
}
