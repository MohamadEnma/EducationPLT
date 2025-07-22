using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EducationPLT.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedCourseCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_ApplicationUserId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_AspNetUsers_ApplicationUserId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses_CourseId",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_ApplicationUserId",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Courses_ApplicationUserId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Enrollments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "PaidAmount",
                table: "Enrollments",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedAt",
                table: "Enrollments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 22, 12, 24, 34, 209, DateTimeKind.Utc).AddTicks(1251),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedUtc",
                table: "Enrollments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 22, 12, 24, 34, 209, DateTimeKind.Utc).AddTicks(168),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Enrollments",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "MohamadEnma",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Courses",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ThumbnailUrl",
                table: "Courses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Courses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "Draft",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Requirements",
                table: "Courses",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000);

            migrationBuilder.AlterColumn<string>(
                name: "PreviewVideoUrl",
                table: "Courses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Courses",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "LearningObjectives",
                table: "Courses",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedAt",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 22, 12, 24, 34, 206, DateTimeKind.Utc).AddTicks(2642),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPublished",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsFree",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Difficulty",
                table: "Courses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "Beginner",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedUtc",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 22, 12, 24, 34, 206, DateTimeKind.Utc).AddTicks(4303),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Courses",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "MohamadEnma",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 22, 12, 24, 34, 206, DateTimeKind.Utc).AddTicks(2111),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "CourseCategories",
                columns: table => new
                {
                    CourseCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IconUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MetaTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2025, 7, 22, 12, 24, 34, 207, DateTimeKind.Utc).AddTicks(8759)),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, defaultValue: "MohamadEnma"),
                    ModifiedUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2025, 7, 6, 11, 24, 28, 0, DateTimeKind.Unspecified)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCategories", x => x.CourseCategoryId);
                });

            migrationBuilder.InsertData(
                table: "CourseCategories",
                columns: new[] { "CourseCategoryId", "ColorCode", "CreatedBy", "CreatedUtc", "DeletedAt", "DeletedBy", "Description", "DisplayOrder", "IconUrl", "ImageUrl", "IsActive", "IsDeleted", "Keywords", "LastModifiedAt", "MetaDescription", "MetaTitle", "ModifiedBy", "ModifiedUtc", "Name", "Slug" },
                values: new object[,]
                {
                    { 1, "#3498db", "MohamadEnma", new DateTime(2025, 7, 6, 11, 24, 28, 0, DateTimeKind.Unspecified), null, null, "Programming and Software Development courses", 1, "https://example.com/icons/programming.png", "", true, false, "programming, software development, coding, courses", new DateTime(2025, 7, 22, 12, 24, 34, 208, DateTimeKind.Utc).AddTicks(8075), "Explore our wide range of programming courses to enhance your coding skills.", "Programming Courses", "MohamadEnma", null, "Programming", "programming" },
                    { 2, "#2ecc71", "MohamadEnma", new DateTime(2025, 7, 22, 12, 24, 34, 208, DateTimeKind.Utc).AddTicks(8082), null, null, "Web Development and Design courses", 1, "https://example.com/icons/web-development.png", "", true, false, "web development, web design, HTML, CSS, JavaScript", new DateTime(2025, 7, 22, 12, 24, 34, 208, DateTimeKind.Utc).AddTicks(8083), "Learn web development from scratch with our comprehensive courses.", "Web Development Courses", "MohamadEnma", null, "Web Development", "web-development" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CompletionDate",
                table: "Enrollments",
                column: "CompletionDate");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_Course_Student",
                table: "Enrollments",
                columns: new[] { "CourseId", "StudentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_EnrollmentDate",
                table: "Enrollments",
                column: "EnrollmentDate");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_LastAccessedAt",
                table: "Enrollments",
                column: "LastAccessedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_PaymentStatus",
                table: "Enrollments",
                column: "PaymentStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_Status",
                table: "Enrollments",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CreatedUtc",
                table: "Courses",
                column: "CreatedUtc");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_PublishStatus",
                table: "Courses",
                columns: new[] { "IsPublished", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Status",
                table: "Courses",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Title",
                table: "Courses",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCategories_DisplayOrder",
                table: "CourseCategories",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCategories_Name",
                table: "CourseCategories",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCategories_Slug",
                table: "CourseCategories",
                column: "Slug",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseCategories_CategoryId",
                table: "Courses",
                column: "CategoryId",
                principalTable: "CourseCategories",
                principalColumn: "CourseCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses_CourseId",
                table: "Enrollments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseCategories_CategoryId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses_CourseId",
                table: "Enrollments");

            migrationBuilder.DropTable(
                name: "CourseCategories");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_CompletionDate",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_Course_Student",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_EnrollmentDate",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_LastAccessedAt",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_PaymentStatus",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_Status",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CreatedUtc",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_PublishStatus",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Status",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Title",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Enrollments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<decimal>(
                name: "PaidAmount",
                table: "Enrollments",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedAt",
                table: "Enrollments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 22, 12, 24, 34, 209, DateTimeKind.Utc).AddTicks(1251));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedUtc",
                table: "Enrollments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 22, 12, 24, 34, 209, DateTimeKind.Utc).AddTicks(168));

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Enrollments",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldDefaultValue: "MohamadEnma");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Enrollments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Courses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ThumbnailUrl",
                table: "Courses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Courses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "Draft");

            migrationBuilder.AlterColumn<string>(
                name: "Requirements",
                table: "Courses",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PreviewVideoUrl",
                table: "Courses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Courses",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LearningObjectives",
                table: "Courses",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedAt",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 22, 12, 24, 34, 206, DateTimeKind.Utc).AddTicks(2642));

            migrationBuilder.AlterColumn<bool>(
                name: "IsPublished",
                table: "Courses",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsFree",
                table: "Courses",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Difficulty",
                table: "Courses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "Beginner");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedUtc",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 22, 12, 24, 34, 206, DateTimeKind.Utc).AddTicks(4303));

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Courses",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldDefaultValue: "MohamadEnma");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 22, 12, 24, 34, 206, DateTimeKind.Utc).AddTicks(2111));

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ApplicationUserId",
                table: "Enrollments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ApplicationUserId",
                table: "Courses",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_ApplicationUserId",
                table: "Courses",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_AspNetUsers_ApplicationUserId",
                table: "Enrollments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses_CourseId",
                table: "Enrollments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
