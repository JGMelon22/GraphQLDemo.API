﻿// <auto-generated />
using System;
using GraphQLDemo.API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GraphQLDemo.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231219121839_StudentsAndInstructorsSeedData")]
    partial class StudentsAndInstructorsSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GraphQLDemo.API.Entities.CourseType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("CourseId");

                    b.Property<Guid>("InstructorId")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("CourseName");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Subject");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .HasDatabaseName("IDX_CourseId_Courses");

                    b.HasIndex("InstructorId")
                        .IsUnique();

                    b.ToTable("Courses", (string)null);
                });

            modelBuilder.Entity("GraphQLDemo.API.Entities.InstructorType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("InstructorId");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("InstructorFirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("InstructorLastName");

                    b.Property<decimal>("Salary")
                        .HasPrecision(10, 2)
                        .HasColumnType("DECIMAL")
                        .HasColumnName("Salary");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .HasDatabaseName("IDX_InstructorId_Instructor");

                    b.ToTable("Instructors", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("693032ca-c9c5-4a6c-8d2c-e5e97fb180f4"),
                            CourseId = new Guid("00000000-0000-0000-0000-000000000000"),
                            FirstName = "Wanda",
                            LastName = "Hamill",
                            Salary = 5934.29m
                        },
                        new
                        {
                            Id = new Guid("e2c963cb-906c-4dab-bbca-59c36cf68744"),
                            CourseId = new Guid("00000000-0000-0000-0000-000000000000"),
                            FirstName = "Raquel",
                            LastName = "Marvin",
                            Salary = 9515.81m
                        },
                        new
                        {
                            Id = new Guid("da7cdd7c-74a5-4ab2-9d51-c2416d190b70"),
                            CourseId = new Guid("00000000-0000-0000-0000-000000000000"),
                            FirstName = "Grant",
                            LastName = "Johnston",
                            Salary = 10235.23m
                        },
                        new
                        {
                            Id = new Guid("1fc0d617-7618-4dd0-a4be-4fcd89abfdc9"),
                            CourseId = new Guid("00000000-0000-0000-0000-000000000000"),
                            FirstName = "Willard",
                            LastName = "Wilkinson",
                            Salary = 3335.47m
                        },
                        new
                        {
                            Id = new Guid("22c28502-bb96-406d-9946-6fc0d52198ae"),
                            CourseId = new Guid("00000000-0000-0000-0000-000000000000"),
                            FirstName = "Lorenzo",
                            LastName = "Halvorson",
                            Salary = 12906.78m
                        },
                        new
                        {
                            Id = new Guid("f6f56539-8f24-453a-abbb-e323b0a65912"),
                            CourseId = new Guid("00000000-0000-0000-0000-000000000000"),
                            FirstName = "Rosie",
                            LastName = "Walker",
                            Salary = 5796.63m
                        },
                        new
                        {
                            Id = new Guid("43d8e76c-508c-48c3-84e8-9abd1eccdf9f"),
                            CourseId = new Guid("00000000-0000-0000-0000-000000000000"),
                            FirstName = "Gertrude",
                            LastName = "Rice",
                            Salary = 12306.79m
                        },
                        new
                        {
                            Id = new Guid("2326a8e3-8dfd-4ecd-9b76-cfec941f7cba"),
                            CourseId = new Guid("00000000-0000-0000-0000-000000000000"),
                            FirstName = "Leonard",
                            LastName = "Quitzon",
                            Salary = 8150.67m
                        },
                        new
                        {
                            Id = new Guid("1a67936d-4ee8-4384-ad1c-c1dce9e00e1d"),
                            CourseId = new Guid("00000000-0000-0000-0000-000000000000"),
                            FirstName = "Victoria",
                            LastName = "Funk",
                            Salary = 6639.79m
                        },
                        new
                        {
                            Id = new Guid("a18d4783-25a8-4c2b-8793-e329935ed611"),
                            CourseId = new Guid("00000000-0000-0000-0000-000000000000"),
                            FirstName = "Kent",
                            LastName = "Lindgren",
                            Salary = 3870.79m
                        });
                });

            modelBuilder.Entity("GraphQLDemo.API.Entities.StudentCourse", b =>
                {
                    b.Property<Guid>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("StudentId");

                    b.Property<Guid>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("CourseId");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId")
                        .HasDatabaseName("IDX_CourseId_StudentsCourses");

                    b.HasIndex("StudentId")
                        .HasDatabaseName("IDX_StudentId_StudentsCourses");

                    b.ToTable("StudentsCourses", (string)null);
                });

            modelBuilder.Entity("GraphQLDemo.API.Entities.StudentType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("StudentId");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("StudentFirstName");

                    b.Property<float>("Gpa")
                        .HasColumnType("REAL")
                        .HasColumnName("Gpa");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("StudentLastName");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .HasDatabaseName("IDX_StudentId_Student");

                    b.ToTable("Students", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("fe274fa3-e524-4d6c-ab7f-017d7a160b27"),
                            FirstName = "Priscilla",
                            Gpa = 2.58f,
                            LastName = "Jast"
                        },
                        new
                        {
                            Id = new Guid("981d4b2a-e2f7-4102-8bc0-472eba2ffeb1"),
                            FirstName = "Dolores",
                            Gpa = 0.53f,
                            LastName = "Satterfield"
                        },
                        new
                        {
                            Id = new Guid("629e80fc-1b49-40ae-9706-fa7d9489c124"),
                            FirstName = "Everett",
                            Gpa = 3.15f,
                            LastName = "Nolan"
                        },
                        new
                        {
                            Id = new Guid("47163697-3916-4935-b84d-1be7ba6ea6a4"),
                            FirstName = "Julius",
                            Gpa = 1f,
                            LastName = "Zboncak"
                        },
                        new
                        {
                            Id = new Guid("787b0819-bd3a-4c07-9e43-abe2f62f54cf"),
                            FirstName = "Leslie",
                            Gpa = 2.4f,
                            LastName = "Kuhlman"
                        },
                        new
                        {
                            Id = new Guid("e9e4e3ca-7d55-4019-a8d8-f41af81b4568"),
                            FirstName = "Doreen",
                            Gpa = 2.25f,
                            LastName = "Schiller"
                        },
                        new
                        {
                            Id = new Guid("1a1c47ed-e190-47f6-a1f6-c644c861f254"),
                            FirstName = "June",
                            Gpa = 2.41f,
                            LastName = "Jacobson"
                        },
                        new
                        {
                            Id = new Guid("ff36ab12-1357-4cde-a881-8275c8960fe3"),
                            FirstName = "Lynn",
                            Gpa = 0.18f,
                            LastName = "Waters"
                        },
                        new
                        {
                            Id = new Guid("4c7dad91-c053-4496-96a1-69b69b0adb6a"),
                            FirstName = "Orlando",
                            Gpa = 0.9f,
                            LastName = "Leuschke"
                        },
                        new
                        {
                            Id = new Guid("bdf3cf7d-4106-4940-b014-0a676d6d6f44"),
                            FirstName = "Salvatore",
                            Gpa = 1.29f,
                            LastName = "Reichel"
                        });
                });

            modelBuilder.Entity("GraphQLDemo.API.Entities.CourseType", b =>
                {
                    b.HasOne("GraphQLDemo.API.Entities.InstructorType", "Instructor")
                        .WithOne("Course")
                        .HasForeignKey("GraphQLDemo.API.Entities.CourseType", "InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("GraphQLDemo.API.Entities.StudentCourse", b =>
                {
                    b.HasOne("GraphQLDemo.API.Entities.CourseType", "Course")
                        .WithMany("StudentsCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GraphQLDemo.API.Entities.StudentType", "Student")
                        .WithMany("StudentsCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("GraphQLDemo.API.Entities.CourseType", b =>
                {
                    b.Navigation("StudentsCourses");
                });

            modelBuilder.Entity("GraphQLDemo.API.Entities.InstructorType", b =>
                {
                    b.Navigation("Course")
                        .IsRequired();
                });

            modelBuilder.Entity("GraphQLDemo.API.Entities.StudentType", b =>
                {
                    b.Navigation("StudentsCourses");
                });
#pragma warning restore 612, 618
        }
    }
}