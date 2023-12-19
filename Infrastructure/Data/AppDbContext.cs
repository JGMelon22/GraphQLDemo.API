using GraphQLDemo.API.Entities;
using GraphQLDemo.API.Infrastructure.Configuration;
using GraphQLDemo.API.Infrastructure.Configuration.Seeding;

namespace GraphQLDemo.API.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<StudentType> Students => Set<StudentType>();
    public DbSet<InstructorType> Instructors => Set<InstructorType>();
    public DbSet<CourseType> Courses => Set<CourseType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new InstructorConfiguration());
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new StudentCourseConfiguration());

        // InitialSeeding.Seed(modelBuilder);
    }
}