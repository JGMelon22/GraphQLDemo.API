using GraphQLDemo.API.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQLDemo.API.Infrastructure.Configuration;

public class StudentConfiguration : IEntityTypeConfiguration<StudentType>
{
    public void Configure(EntityTypeBuilder<StudentType> builder)
    {
        builder.ToTable("Students");

        builder.HasKey(s => s.Id);

        builder.HasIndex(s => s.Id)
            .HasDatabaseName("IDX_StudentId_Student")
            ;

        builder.Property(s => s.Id)
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasColumnName("StudentId")
            .ValueGeneratedOnAdd();

        builder.Property(s => s.FirstName)
            .HasColumnType("VARCHAR")
            .HasColumnName("StudentFirstName")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(s => s.LastName)
            .HasColumnType("VARCHAR")
            .HasColumnName("StudentLastName")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(s => s.Gpa)
            .HasColumnType("REAL")
            .HasColumnName("Gpa")
            .IsRequired();
    }
}