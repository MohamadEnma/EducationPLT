﻿using EducationPLT.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPLT.DAL.Models.CourseEntities
{
    public class CourseCategory : IAuditableEntity
    {

        [Key]
        public int CourseCategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        // Display Order
        public int DisplayOrder { get; set; }

        // Icon/Image
        [StringLength(500)]
        public string IconUrl { get; set; } = string.Empty;

        [StringLength(500)]
        public string ImageUrl { get; set; } = string.Empty;

        [StringLength(7)] // #RRGGBB format
        public string ColorCode { get; set; } = string.Empty;

        // Status
        public bool IsActive { get; set; }

        // Navigation Property
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

        // SEO Properties
        [StringLength(100)]
        public string Slug { get; set; } = string.Empty;

        [StringLength(200)]
        public string MetaTitle { get; set; } = string.Empty;

        [StringLength(500)]
        public string MetaDescription { get; set; } = string.Empty;

        [StringLength(200)]
        public string Keywords { get; set; } = string.Empty;

        // Audit Fields
        [Required]
        public DateTime CreatedUtc { get; set; }

        [Required]
        [StringLength(256)]
        public string CreatedBy { get; set; } = string.Empty;

        public DateTime? ModifiedUtc { get; set; }

        [StringLength(256)]
        public string ModifiedBy { get; set; } = string.Empty;

        [Required]
        public DateTime LastModifiedAt { get; set; }

        // Soft Delete
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }

        // Statistics (Not mapped to database)
        [NotMapped]
        public int ActiveCoursesCount => Courses?.Count(c => c.IsPublished && !c.IsDeleted) ?? 0;


    }
}
