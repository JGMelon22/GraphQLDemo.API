using FluentValidation;
using FluentValidation.Results;
using GraphQLDemo.API.DTOs.Course;
using GraphQLDemo.API.DTOs.Instructor;
using GraphQLDemo.API.DTOs.Student;
using GraphQLDemo.API.Entities;
using GraphQLDemo.API.Interfaces;

namespace GraphQLDemo.API.GraphQL.Mutations;

public class MutationType
{
    private readonly IValidator<StudentInput> _studentInputValidator;
    private readonly IValidator<InstructorInput> _instructorInputValidator;
    private readonly IValidator<CourseInput> _courseInputValidator;

    public MutationType(IValidator<StudentInput> studentInputValidator,
        IValidator<InstructorInput> instructorInputValidator, IValidator<CourseInput> courseInputValidator)
    {
        _studentInputValidator = studentInputValidator;
        _instructorInputValidator = instructorInputValidator;
        _courseInputValidator = courseInputValidator;
    }

    // Student
    public async Task<ServiceResponse<StudentResult>> AddStudentAsync([Service] IStudentRepository studentRepository,
        StudentInput newStudent)
    {
        ValidationResult result = await _studentInputValidator.ValidateAsync(newStudent);

        if (!result.IsValid)
            throw new GraphQLException(string.Join(',', result.Errors));

        return await studentRepository.AddStudentAsync(newStudent);
    }

    public async Task<ServiceResponse<StudentResult>> UpdateStudentAsync([Service] IStudentRepository studentRepository,
        Guid id, StudentInput updatedStudent)
    {
        ValidationResult result = await _studentInputValidator.ValidateAsync(updatedStudent);

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
        ValidationResult result = await _instructorInputValidator.ValidateAsync(newInstructor);

        if (!result.IsValid)
            throw new GraphQLException(string.Join(',', result.Errors));

        return await instructorRepository.AddInstructorAsync(newInstructor);
    }

    public async Task<ServiceResponse<InstructorResult>> UpdateInstructorAsync(
        [Service] IInstructorRepository instructorRepository, Guid id, InstructorInput updatedInstructor)
    {
        ValidationResult result = await _instructorInputValidator.ValidateAsync(updatedInstructor);

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
        ValidationResult result = await _courseInputValidator.ValidateAsync(newCourse);

        if (!result.IsValid)
            throw new GraphQLException(string.Join(',', result.Errors));

        return await courseRepository.AddCourseAsync(newCourse);
    }

    public async Task<ServiceResponse<CourseResult>> UpdateCourseAsync([Service] ICourseRepository courseRepository,
        Guid id, CourseInput updatedCourse)
    {
        ValidationResult result = await _courseInputValidator.ValidateAsync(updatedCourse);

        if (!result.IsValid)
            throw new GraphQLException(string.Join(',', result.Errors));

        return await courseRepository.UpdateCourseAsync(id, updatedCourse);
    }

    public async Task<ServiceResponse<bool>> RemoveCourseAsync([Service] ICourseRepository courseRepository, Guid id)
    {
        return await courseRepository.RemoveCourseAsync(id);
    }
}