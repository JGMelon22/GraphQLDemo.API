namespace GraphQLDemo.API.Entities;

public class CourseType
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public Subject Subject { get; set; }

    public Guid InstructorId { get; set; }
    [GraphQLNonNullType] public InstructorType Instructor { get; set; } = null!;

    public IEnumerable<StudentCourse> StudentsCourses { get; set; } = null!;
}