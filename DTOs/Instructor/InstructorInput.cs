namespace GraphQLDemo.API.DTOs.Instructor;

public record InstructorInput(string FirstName, string LastName, decimal Salary, Guid CourseId);