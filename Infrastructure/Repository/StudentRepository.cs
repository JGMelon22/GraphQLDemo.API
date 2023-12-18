using GraphQLDemo.API.DTOs.Student;
using GraphQLDemo.API.Entities;
using GraphQLDemo.API.Infrastructure.Data;
using GraphQLDemo.API.Interfaces;

namespace GraphQLDemo.API.Infrastructure.Repository;

public class StudentRepository : IStudentRepository
{
    private static readonly Func<AppDbContext, Guid, Task<StudentResult?>> GetById =
        EF.CompileAsyncQuery((AppDbContext context, Guid id) =>
            context.Students
                .Select(s => new StudentResult
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Gpa = s.Gpa
                }).FirstOrDefault(s => s.Id == id));

    private readonly AppDbContext _dbContext;

    public StudentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ServiceResponse<List<StudentResult>>> GetAllStudentsAsync()
    {
        var serviceResponse = new ServiceResponse<List<StudentResult>>();

        try
        {
            var students = await _dbContext.Students
                .AsNoTracking()
                .ToListAsync();

            var studentsMapped = new List<StudentResult>();

            foreach (var student in students)
            {
                var studentResult = new StudentResult
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Gpa = student.Gpa
                };

                studentsMapped.Add(studentResult);
                serviceResponse.Data = studentsMapped;
            }
        }

        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<StudentResult>> GetStudentByIdAsync(Guid id)
    {
        var serviceResponse = new ServiceResponse<StudentResult>();

        try
        {
            var student = await GetById(_dbContext, id);

            if (student is null) throw new GraphQLException(new Error("Student not found!", "STUDENT_NOT_FOUND"));

            serviceResponse.Data = student;
        }

        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<StudentResult>> AddStudentAsync(StudentInput newStudent)
    {
        var serviceResponse = new ServiceResponse<StudentResult>();

        try
        {
            StudentType student = new StudentType
            {
                Id = Guid.NewGuid(),
                FirstName = newStudent.FirstName,
                LastName = newStudent.LastName,
                Gpa = newStudent.Gpa
            };

            await _dbContext.AddAsync(student);
            await _dbContext.SaveChangesAsync();
            
            var studentResult = new StudentResult
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Gpa = student.Gpa
            };

            serviceResponse.Data = studentResult;
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<StudentResult>> UpdateStudentAsync(Guid id, StudentInput updatedStudent)
    {
        var serviceResponse = new ServiceResponse<StudentResult>();

        try
        {
            var student = await _dbContext.Students.FindAsync(id);

            if (student is null)
                throw new GraphQLException(new Error("Student not found!", "STUDENT_NOT_FOUND"));
            
            // Update data and save (manual map)
            student.FirstName = updatedStudent.FirstName;
            student.LastName = updatedStudent.LastName;
            student.Gpa = updatedStudent.Gpa;

            await _dbContext.SaveChangesAsync();

            // Return based on studentResult
            var studentResult = new StudentResult
            {
                Id = student.Id,
                FirstName = updatedStudent.FirstName,
                LastName = updatedStudent.LastName,
                Gpa = updatedStudent.Gpa
            };

            serviceResponse.Data = studentResult;
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }


    public async Task<ServiceResponse<bool>> RemoveStudentAsync(Guid id)
    {
        var serviceResponse = new ServiceResponse<bool>();

        try
        {
            var student = await _dbContext.Students.FindAsync(id);

            if (student is null)
                throw new GraphQLException(new Error("Course not found!", "COURSE_NOT_FOUND"));

            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();

            serviceResponse.Success = true;
        }

        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }
}