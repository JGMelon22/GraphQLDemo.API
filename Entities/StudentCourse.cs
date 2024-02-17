namespace GraphQLDemo.API.Entities;

public class StudentCourse
{
    public Guid StudentId { get; set; }
    public StudentType Student { get; set; } = null!;
    public Guid CourseId { get; set; }
    public CourseType Course { get; set; } = null!;
}