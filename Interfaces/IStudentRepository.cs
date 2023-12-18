using GraphQLDemo.API.DTOs.Student;
using GraphQLDemo.API.Entities;

namespace GraphQLDemo.API.Interfaces;

public interface IStudentRepository
{
    Task<ServiceResponse<List<StudentResult>>> GetAllStudentsAsync();
    Task<ServiceResponse<StudentResult>> GetStudentByIdAsync(Guid id);
    Task<ServiceResponse<StudentResult>> AddStudentAsync(StudentInput newStudent);
    Task<ServiceResponse<StudentResult>> UpdateStudentAsync(Guid id, StudentInput updatedStudent);
    Task<ServiceResponse<bool>> RemoveStudentAsync(Guid id);
}