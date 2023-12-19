using GraphQLDemo.API.DTOs.Course;
using GraphQLDemo.API.DTOs.Instructor;
using GraphQLDemo.API.DTOs.Student;
using GraphQLDemo.API.Entities;
using GraphQLDemo.API.Interfaces;

namespace GraphQLDemo.API.GraphQL.Mutations;

public class MutationType
{
    // Student
    public async Task<ServiceResponse<StudentResult>> AddStudentAsync([Service] IStudentRepository studentRepository,
        StudentInput newStudent)
    {
        return await studentRepository.AddStudentAsync(newStudent);
    }

    public async Task<ServiceResponse<StudentResult>> UpdateStudentAsync([Service] IStudentRepository studentRepository,
        Guid id, StudentInput updatedStudent)
    {
        return await studentRepository.UpdateStudentAsync(id, updatedStudent);
    }

    public async Task<ServiceResponse<bool>> RemoveStudentAsyncAsync([Service] IStudentRepository studentRepository,
        Guid id)
    {
        return await studentRepository.RemoveStudentAsync(id);
    }

    // Instructor
    public async Task<ServiceResponse<InstructorResult>> AddInstructorAsync(
        [Service] IInstructorRepository instructorRepository, InstructorInput newInstructor)
    {
        return await instructorRepository.AddInstructorAsync(newInstructor);
    }

    public async Task<ServiceResponse<InstructorResult>> UpdateInstructorAsync(
        [Service] IInstructorRepository instructorRepository, Guid id, InstructorInput updatedInstructor)
    {
        return await instructorRepository.UpdateInstructorAsync(id, updatedInstructor);
    }

    public async Task<ServiceResponse<bool>> RemoveInstructorAsyncAsync(
        [Service] IInstructorRepository instructorRepository, Guid id)
    {
        return await instructorRepository.RemoveInstructor(id);
    }

    // Course
    public async Task<ServiceResponse<CourseResult>> AddCourseAsync([Service] ICourseRepository courseRepository,
        CourseInput newCourse)
    {
        return await courseRepository.AddCourseAsync(newCourse);
    }

    public async Task<ServiceResponse<CourseResult>> UpdateCourseAsync([Service] ICourseRepository courseRepository,
        Guid id, CourseInput updatedCourse)
    {
        return await courseRepository.UpdateCourseAsync(id, updatedCourse);
    }

    public async Task<ServiceResponse<bool>> RemoveCourseAsync([Service] ICourseRepository courseRepository, Guid id)
    {
        return await courseRepository.RemoveCourseAsync(id);
    }
}