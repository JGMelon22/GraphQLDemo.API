using FluentValidation;
using GraphQLDemo.API.DTOs.Course;
using GraphQLDemo.API.DTOs.Instructor;
using GraphQLDemo.API.DTOs.Student;
using GraphQLDemo.API.Entities;
using GraphQLDemo.API.Interfaces;

namespace GraphQLDemo.API.GraphQL.Mutations;

public class MutationType(
    IValidator<StudentInput> studentInputValidator,
    IValidator<InstructorInput> instructorInputValidator,
    IValidator<CourseInput> courseInputValidator)
{
    // Student
    public async Task<ServiceResponse<StudentResult>> AddStudentAsync([Service] IStudentRepository studentRepository,
        StudentInput newStudent)
    {
        var result = await studentInputValidator.ValidateAsync(newStudent);

        if (!result.IsValid)
            throw new GraphQLException(string.Join(',', result.Errors));

        return await studentRepository.AddStudentAsync(newStudent);
    }

    public async Task<ServiceResponse<StudentResult>> UpdateStudentAsync([Service] IStudentRepository studentRepository,
        Guid id, StudentInput updatedStudent)
    {
        var result = await studentInputValidator.ValidateAsync(updatedStudent);

        if (!result.IsValid)
            throw new GraphQLException(string.Join(',', result.Errors));

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
        var result = await instructorInputValidator.ValidateAsync(newInstructor);

        if (!result.IsValid)
            throw new GraphQLException(string.Join(',', result.Errors));

        return await instructorRepository.AddInstructorAsync(newInstructor);
    }

    public async Task<ServiceResponse<InstructorResult>> UpdateInstructorAsync(
        [Service] IInstructorRepository instructorRepository, Guid id, InstructorInput updatedInstructor)
    {
        var result = await instructorInputValidator.ValidateAsync(updatedInstructor);

        if (!result.IsValid)
            throw new GraphQLException(string.Join(',', result.Errors));

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
        var result = await courseInputValidator.ValidateAsync(newCourse);

        if (!result.IsValid)
            throw new GraphQLException(string.Join(',', result.Errors));

        return await courseRepository.AddCourseAsync(newCourse);
    }

    public async Task<ServiceResponse<CourseResult>> UpdateCourseAsync([Service] ICourseRepository courseRepository,
        Guid id, CourseInput updatedCourse)
    {
        var result = await courseInputValidator.ValidateAsync(updatedCourse);

        if (!result.IsValid)
            throw new GraphQLException(string.Join(',', result.Errors));

        return await courseRepository.UpdateCourseAsync(id, updatedCourse);
    }

    public async Task<ServiceResponse<bool>> RemoveCourseAsync([Service] ICourseRepository courseRepository, Guid id)
    {
        return await courseRepository.RemoveCourseAsync(id);
    }
}