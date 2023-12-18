using GraphQLDemo.API.Entities;

namespace GraphQLDemo.API.DTOs.Course;

public class CourseResult
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public Subject Subject { get; set; }
    public Guid InstructorId { get; set; }
}