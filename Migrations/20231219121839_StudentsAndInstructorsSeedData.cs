using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GraphQLDemo.API.Migrations
{
    /// <inheritdoc />
    public partial class StudentsAndInstructorsSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "InstructorId", "CourseId", "InstructorFirstName", "InstructorLastName", "Salary" },
                values: new object[,]
                {
                    { new Guid("1a67936d-4ee8-4384-ad1c-c1dce9e00e1d"), new Guid("00000000-0000-0000-0000-000000000000"), "Victoria", "Funk", 6639.79m },
                    { new Guid("1fc0d617-7618-4dd0-a4be-4fcd89abfdc9"), new Guid("00000000-0000-0000-0000-000000000000"), "Willard", "Wilkinson", 3335.47m },
                    { new Guid("22c28502-bb96-406d-9946-6fc0d52198ae"), new Guid("00000000-0000-0000-0000-000000000000"), "Lorenzo", "Halvorson", 12906.78m },
                    { new Guid("2326a8e3-8dfd-4ecd-9b76-cfec941f7cba"), new Guid("00000000-0000-0000-0000-000000000000"), "Leonard", "Quitzon", 8150.67m },
                    { new Guid("43d8e76c-508c-48c3-84e8-9abd1eccdf9f"), new Guid("00000000-0000-0000-0000-000000000000"), "Gertrude", "Rice", 12306.79m },
                    { new Guid("693032ca-c9c5-4a6c-8d2c-e5e97fb180f4"), new Guid("00000000-0000-0000-0000-000000000000"), "Wanda", "Hamill", 5934.29m },
                    { new Guid("a18d4783-25a8-4c2b-8793-e329935ed611"), new Guid("00000000-0000-0000-0000-000000000000"), "Kent", "Lindgren", 3870.79m },
                    { new Guid("da7cdd7c-74a5-4ab2-9d51-c2416d190b70"), new Guid("00000000-0000-0000-0000-000000000000"), "Grant", "Johnston", 10235.23m },
                    { new Guid("e2c963cb-906c-4dab-bbca-59c36cf68744"), new Guid("00000000-0000-0000-0000-000000000000"), "Raquel", "Marvin", 9515.81m },
                    { new Guid("f6f56539-8f24-453a-abbb-e323b0a65912"), new Guid("00000000-0000-0000-0000-000000000000"), "Rosie", "Walker", 5796.63m }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "StudentFirstName", "Gpa", "StudentLastName" },
                values: new object[,]
                {
                    { new Guid("1a1c47ed-e190-47f6-a1f6-c644c861f254"), "June", 2.41f, "Jacobson" },
                    { new Guid("47163697-3916-4935-b84d-1be7ba6ea6a4"), "Julius", 1f, "Zboncak" },
                    { new Guid("4c7dad91-c053-4496-96a1-69b69b0adb6a"), "Orlando", 0.9f, "Leuschke" },
                    { new Guid("629e80fc-1b49-40ae-9706-fa7d9489c124"), "Everett", 3.15f, "Nolan" },
                    { new Guid("787b0819-bd3a-4c07-9e43-abe2f62f54cf"), "Leslie", 2.4f, "Kuhlman" },
                    { new Guid("981d4b2a-e2f7-4102-8bc0-472eba2ffeb1"), "Dolores", 0.53f, "Satterfield" },
                    { new Guid("bdf3cf7d-4106-4940-b014-0a676d6d6f44"), "Salvatore", 1.29f, "Reichel" },
                    { new Guid("e9e4e3ca-7d55-4019-a8d8-f41af81b4568"), "Doreen", 2.25f, "Schiller" },
                    { new Guid("fe274fa3-e524-4d6c-ab7f-017d7a160b27"), "Priscilla", 2.58f, "Jast" },
                    { new Guid("ff36ab12-1357-4cde-a881-8275c8960fe3"), "Lynn", 0.18f, "Waters" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("1a67936d-4ee8-4384-ad1c-c1dce9e00e1d"));

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("1fc0d617-7618-4dd0-a4be-4fcd89abfdc9"));

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("22c28502-bb96-406d-9946-6fc0d52198ae"));

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("2326a8e3-8dfd-4ecd-9b76-cfec941f7cba"));

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("43d8e76c-508c-48c3-84e8-9abd1eccdf9f"));

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("693032ca-c9c5-4a6c-8d2c-e5e97fb180f4"));

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("a18d4783-25a8-4c2b-8793-e329935ed611"));

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("da7cdd7c-74a5-4ab2-9d51-c2416d190b70"));

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("e2c963cb-906c-4dab-bbca-59c36cf68744"));

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("f6f56539-8f24-453a-abbb-e323b0a65912"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("1a1c47ed-e190-47f6-a1f6-c644c861f254"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("47163697-3916-4935-b84d-1be7ba6ea6a4"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("4c7dad91-c053-4496-96a1-69b69b0adb6a"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("629e80fc-1b49-40ae-9706-fa7d9489c124"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("787b0819-bd3a-4c07-9e43-abe2f62f54cf"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("981d4b2a-e2f7-4102-8bc0-472eba2ffeb1"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("bdf3cf7d-4106-4940-b014-0a676d6d6f44"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("e9e4e3ca-7d55-4019-a8d8-f41af81b4568"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("fe274fa3-e524-4d6c-ab7f-017d7a160b27"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("ff36ab12-1357-4cde-a881-8275c8960fe3"));
        }
    }
}
