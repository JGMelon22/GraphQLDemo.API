namespace GraphQLDemo.API.Entities;

public class InstructorType
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public decimal Salary { get; set; }
    public Guid CourseId { get; set; }
    public CourseType Course { get; set; } = null!;
}