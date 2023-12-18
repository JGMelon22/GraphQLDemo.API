namespace GraphQLDemo.API.DTOs.Student;

public record StudentResult
{
    public Guid Id { get; init; }
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public double Gpa { get; init; }
}