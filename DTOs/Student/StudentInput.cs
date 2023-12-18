namespace GraphQLDemo.API.DTOs.Student;

public record StudentInput(string FirstName, string LastName, [GraphQLName("gpa")] double Gpa);