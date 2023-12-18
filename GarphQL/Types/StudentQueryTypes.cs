using GraphQLDemo.API.DTOs.Student;
using GraphQLDemo.API.Entities;
using GraphQLDemo.API.Interfaces;

namespace GraphQLDemo.API.GarphQL.Types;

public class StudentQueryTypes
{
    public async Task<ServiceResponse<List<StudentResult>>> GetAllStudents(
        [Service] IStudentRepository studentRepository)
    {
        return await studentRepository.GetAllStudentsAsync();
    }

    public async Task<ServiceResponse<StudentResult>> GetStudentById([Service] IStudentRepository studentRepository,
        Guid studentId)
    {
        return await studentRepository.GetStudentByIdAsync(studentId);
    }
}