namespace GraphQLDemo.API.DTOs.Instructor;

public record InstructorResult
{
    public Guid Id { get; init; }
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public decimal Salary { get; init; }
    public Guid CourseId { get; init; }
}