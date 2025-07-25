﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPLT.DAL.Models.UserEntities;

namespace EducationPLT.DAL.Models.CourseEntities
{
     public class Course
        {
            [Key]
            public int CourseId { get; set; }
            [Required]
            [StringLength(100, ErrorMessage = "Course Title cannot exceed 200 characters.")]
            public string Title { get; set; } = string.Empty;

            [Required]
            [StringLength(500, ErrorMessage = "Course Description cannot exceed 500 characters.")]
            public string Description { get; set; } = string.Empty;

            // course setting
            
            public bool IsPublished { get; set; } = false;
            
            public CourseStatus Status { get; set; } = CourseStatus.Draft;

            [Required]
            public CourseDifficulty Difficulty { get; set; }

            // Dates
            [Required]
            public DateTime CreatedAt { get; set; }

          
            public DateTime LastModifiedAt { get; set; }

            public DateTime? PublishedAt { get; set; }

            public DateTime? StartDate { get; set; }

            public DateTime? EndDate { get; set; }

            public int MaxStudents { get; set; } = 100; // Default max students

            // Duration in minutes
            public int? EstimatedDuration { get; set; }

            // Pricing
            [Column(TypeName = "decimal(18,2)")]
            public decimal? Price { get; set; }

            public bool IsFree { get; set; }

            // Instructor/Owner
            [Required]
            [ForeignKey("InstructorId")]
            public string InstructorId { get; set; } = string.Empty;

            public virtual ApplicationUser Instructor { get; set; }

            // Course Category/Topic
            [ForeignKey("CourseCategoryId")]
            public int? CategoryId { get; set; }
            public virtual CourseCategory Category { get; set; }


        // Thumbnail/Preview
        [StringLength(500)]
            public string ThumbnailUrl { get; set; } = string.Empty;

            [StringLength(500)]
            public string PreviewVideoUrl { get; set; } = string.Empty;

            // Requirements and Learning Objectives
            [StringLength(4000)]
            public string Requirements { get; set; } = string.Empty;

            [StringLength(4000)]
            public string LearningObjectives { get; set; } = string.Empty;

            // Audit Fields
            [Required]
            public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;

            [Required]
            [StringLength(256)]
            public string CreatedBy { get; set; } = "MohamadEnma"; // Current user's login

            public DateTime? ModifiedUtc { get; set; }

            [StringLength(256)]
            public string ModifiedBy { get; set; } = string.Empty;

            public bool IsDeleted { get; set; }
            public DateTime DeletedAt { get; set; }
            public string DeletedBy { get; set; } = string.Empty;

            public List<Enrollment> Enrollments { get; set; } = new();
        }
        public enum CourseStatus
        {
            Draft,
            PendingReview,
            Active,
            Inactive,
            Archived
        }

        public enum CourseDifficulty
        {
            Beginner,
            Intermediate,
            Advanced,
            Expert
        }
    
}
