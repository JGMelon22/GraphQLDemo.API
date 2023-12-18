using GraphQLDemo.API.DTOs.Instructor;
using GraphQLDemo.API.Entities;

namespace GraphQLDemo.API.Interfaces;

public interface IInstructorRepository
{
    Task<ServiceResponse<List<InstructorResult>>> GetAllInstructorsAsync();
    Task<ServiceResponse<InstructorResult>> GetInstructorByIdAsync(Guid id);
    Task<ServiceResponse<InstructorResult>> AddInstructorAsync(InstructorInput newInstructor);
    Task<ServiceResponse<InstructorResult>> UpdateInstructorAsync(Guid id, InstructorInput updatedInstructor);
    Task<bool> RemoveInstructor(Guid id);
}