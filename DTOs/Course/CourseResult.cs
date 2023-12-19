using GraphQLDemo.API.Entities;

namespace GraphQLDemo.API.DTOs.Course;

public record CourseResult
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public Subject Subject { get; init; }
    public Guid InstructorId { get; init; }
}