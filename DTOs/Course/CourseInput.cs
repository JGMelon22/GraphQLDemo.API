using GraphQLDemo.API.Entities;

namespace GraphQLDemo.API.DTOs.Course;

public record CourseInput
{
    public string Name { get; init; } = null!;
    public Subject Subject { get; init; }
    public Guid InstructorId { get; init; }
}