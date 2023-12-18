using GraphQLDemo.API.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQLDemo.API.Infrastructure.Configuration;

public class InstructorConfiguration : IEntityTypeConfiguration<InstructorType>
{
    public void Configure(EntityTypeBuilder<InstructorType> builder)
    {
        builder.ToTable("Instructors");

        builder.HasKey(i => i.Id);

        builder.HasIndex(i => i.Id)
            .HasDatabaseName("IDX_InstructorId_Instructor")
            ;

        builder.Property(i => i.Id)
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasColumnName("InstructorId")
            .ValueGeneratedOnAdd();

        builder.Property(i => i.FirstName)
            .HasColumnType("VARCHAR")
            .HasColumnName("InstructorFirstName")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(i => i.LastName)
            .HasColumnType("VARCHAR")
            .HasColumnName("InstructorLastName")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(i => i.Salary)
            .HasColumnType("DECIMAL")
            .HasColumnName("Salary")
            .HasPrecision(10, 2)
            .IsRequired();

        // FK
        builder.HasOne(i => i.Course)
            .WithOne(c => c.Instructor)
            .HasForeignKey<InstructorType>(i => i.CourseId);
    }
}