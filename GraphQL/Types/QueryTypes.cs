using GraphQLDemo.API.DTOs.Course;
using GraphQLDemo.API.DTOs.Instructor;
using GraphQLDemo.API.DTOs.Student;
using GraphQLDemo.API.Entities;
using GraphQLDemo.API.Interfaces;

namespace GraphQLDemo.API.GraphQL.Types;

public class QueryTypes
{
    // Student
    public async Task<ServiceResponse<List<StudentResult>>> GetAllStudentsAsync(
        [Service] IStudentRepository studentRepository)
    {
        return await studentRepository.GetAllStudentsAsync();
    }

    public async Task<ServiceResponse<StudentResult>> GetStudentByIdAsync(
        [Service] IStudentRepository studentRepository,
        Guid studentId)
    {
        return await studentRepository.GetStudentByIdAsync(studentId);
    }

    // Instructor
    public async Task<ServiceResponse<List<InstructorResult>>> GetAllInstructorsAsync(
        [Service] IInstructorRepository instructorRepository)
    {
        return await instructorRepository.GetAllInstructorsAsync();
    }

    public async Task<ServiceResponse<InstructorResult>> GetInstructorByIdAsync(
        [Service] IInstructorRepository instructorRepository,
        Guid id)
    {
        return await instructorRepository.GetInstructorByIdAsync(id);
    }

    // Course
    public async Task<ServiceResponse<List<CourseResult>>> GetAllCoursesAsync(
        [Service] ICourseRepository courseRepository)
    {
        return await courseRepository.GetAllCoursesAsync();
    }

    public async Task<ServiceResponse<CourseResult>> GetCourseByIdAsync([Service] ICourseRepository courseRepository,
        Guid id)
    {
        return await courseRepository.GetCourseByIdAsync(id);
    }
}