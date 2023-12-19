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
}