using Bogus;
using GraphQLDemo.API.Entities;

namespace GraphQLDemo.API.Infrastructure.Configuration.Seeding;

public static class InitialSeeding
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // Students
        var students = new Faker<StudentType>()
            .RuleFor(s => s.Id, f => Guid.NewGuid())
            .RuleFor(s => s.FirstName, f => f.Person.FirstName)
            .RuleFor(s => s.LastName, f => f.Person.LastName)
            .RuleFor(s => s.Gpa, f => Math.Round(f.Random.Double(0.0, 4.0), 2))
            .Generate(10);

        // Instructors
        var instructors = new Faker<InstructorType>()
            .RuleFor(i => i.Id, f => Guid.NewGuid())
            .RuleFor(i => i.FirstName, f => f.Person.FirstName)
            .RuleFor(i => i.LastName, f => f.Person.LastName)
            .RuleFor(i => i.Salary, f => Math.Round(f.Random.Decimal(2400.00M, 15000.00M), 2))
            .Generate(10);

        // Courses
        var courses = new Faker<CourseType>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Name, f => f.Name.JobArea())
            .RuleFor(c => c.Subject, f => f.PickRandom<Subject>())
            .RuleFor(c => c.InstructorId, f => f.PickRandom(instructors).Id)
            .Generate(10);

        // StudentsCourses
        var studentsCourses = new Faker<StudentCourse>()
            .RuleFor(sc => sc.StudentId, f => f.PickRandom(students).Id)
            .RuleFor(sc => sc.CourseId, f => f.PickRandom(courses).Id)
            .Generate(10);

        modelBuilder.Entity<StudentType>()
            .HasData(students);
        
        modelBuilder.Entity<InstructorType>()
            .HasData(instructors);

        modelBuilder.Entity<CourseType>()
            .HasData(courses);

        modelBuilder.Entity<StudentCourse>()
            .HasData(studentsCourses);
    }
}