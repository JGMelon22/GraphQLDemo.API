using GraphQLDemo.API.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQLDemo.API.Infrastructure.Configuration;

public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
{
    public void Configure(EntityTypeBuilder<StudentCourse> builder)
    {
        builder.ToTable("StudentsCourses");

        builder.HasKey(sc => new
        {
            sc.StudentId,
            sc.CourseId
        });

        builder.HasIndex(sc => sc.StudentId)
            .HasDatabaseName("IDX_StudentId_StudentsCourses");

        builder.HasIndex(sc => sc.CourseId)
            .HasDatabaseName("IDX_CourseId_StudentsCourses");

        builder.Property(sc => sc.StudentId)
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasColumnName("StudentId")
            .ValueGeneratedOnAdd();

        builder.Property(sc => sc.CourseId)
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasColumnName("CourseId")
            .ValueGeneratedOnAdd();

        // FKs
        builder.HasOne(sc => sc.Student)
            .WithMany(s => s.StudentsCourses)
            .HasForeignKey(sc => sc.StudentId);

        builder.HasOne(sc => sc.Course)
            .WithMany(s => s.StudentsCourses)
            .HasForeignKey(sc => sc.CourseId);
    }
}