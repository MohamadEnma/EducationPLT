using EducationPLT.DAL.Models.CourseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPLT.DAL.Configurations
{
    public class CourseCategoryConfiguration : IEntityTypeConfiguration<CourseCategory>
    {
        public void Configure(EntityTypeBuilder<CourseCategory> builder)
        {
            builder.ToTable("CourseCategories");

            // Primary Key
            builder.HasKey(cc => cc.CourseCategoryId);
            // Properties
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Description)
                .HasMaxLength(500);

            builder.Property(c => c.IconUrl)
                .HasMaxLength(500);

            builder.Property(c => c.ColorCode)
                .HasMaxLength(7);

            builder.Property(c => c.Slug)
                .HasMaxLength(100);

            builder.Property(c => c.MetaTitle)
                .HasMaxLength(200);

            builder.Property(c => c.MetaDescription)
                .HasMaxLength(500);

            builder.Property(c => c.Keywords)
                .HasMaxLength(200);

            // Audit Fields
            builder.Property(c => c.CreatedUtc)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow);

            builder.Property(c => c.CreatedBy)
                .IsRequired()
                .HasMaxLength(256)
                .HasDefaultValue("MohamadEnma");

            builder.Property(c => c.LastModifiedAt)
                .IsRequired()
                .HasDefaultValue(DateTime.Parse("2025-07-06 11:24:28"));


            // Relationships with Courses
            builder.HasMany(c => c.Courses)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(c => c.Name)
                .HasDatabaseName("IX_CourseCategories_Name");

            builder.HasIndex(c => c.Slug)
                .HasDatabaseName("IX_CourseCategories_Slug")
                .IsUnique();

            builder.HasIndex(c => c.DisplayOrder)
                .HasDatabaseName("IX_CourseCategories_DisplayOrder");

            // Query Filter
            builder.HasQueryFilter(c => !c.IsDeleted);

        }
    }
}
