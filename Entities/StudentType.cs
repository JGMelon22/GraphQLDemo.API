namespace GraphQLDemo.API.Entities;

public class StudentType
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public double Gpa { get; set; }
    public IEnumerable<StudentCourse> StudentsCourses { get; set; } = null!;
}