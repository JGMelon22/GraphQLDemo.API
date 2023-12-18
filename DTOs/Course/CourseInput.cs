using GraphQLDemo.API.Entities;

namespace GraphQLDemo.API.DTOs.Course;

public record CourseInput(string Name, Subject Subject, Guid InstructorId);