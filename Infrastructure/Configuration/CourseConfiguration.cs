using GraphQLDemo.API.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQLDemo.API.Infrastructure.Configuration;

public class CourseConfiguration : IEntityTypeConfiguration<CourseType>
{
    public void Configure(EntityTypeBuilder<CourseType> builder)
    {
        builder.ToTable("Courses");

        builder.HasKey(c => c.Id);

        builder.HasIndex(c => c.Id)
            .HasDatabaseName("IDX_CourseId_Courses");

        builder.Property(c => c.Id)
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasColumnName("CourseId")
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Name)
            .HasColumnType("VARCHAR")
            .HasColumnName("CourseName")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Subject)
            .HasColumnType("VARCHAR")
            .HasColumnName("Subject")
            .HasMaxLength(100)
            .IsRequired();

        // FK
        builder.HasOne(c => c.Instructor)
            .WithOne(i => i.Course)
            .HasForeignKey<CourseType>(c => c.InstructorId);
    }
}