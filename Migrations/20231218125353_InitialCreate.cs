using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphQLDemo.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    InstructorId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    InstructorFirstName = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    InstructorLastName = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Salary = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.InstructorId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    StudentFirstName = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    StudentLastName = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Gpa = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    CourseName = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Subject = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    InstructorId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "InstructorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsCourses",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    CourseId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsCourses", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_StudentsCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_CourseId_Courses",
                table: "Courses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IDX_InstructorId_Instructor",
                table: "Instructors",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IDX_StudentId_Student",
                table: "Students",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IDX_CourseId_StudentsCourses",
                table: "StudentsCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IDX_StudentId_StudentsCourses",
                table: "StudentsCourses",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsCourses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Instructors");
        }
    }
}
