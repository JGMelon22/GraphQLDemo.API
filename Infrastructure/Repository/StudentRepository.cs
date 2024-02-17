using GraphQLDemo.API.DTOs.Student;
using GraphQLDemo.API.Entities;
using GraphQLDemo.API.Interfaces;

namespace GraphQLDemo.API.Infrastructure.Repository;

public class StudentRepository(AppDbContext dbContext) : IStudentRepository
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

    public async Task<ServiceResponse<List<StudentResult>>> GetAllStudentsAsync()
    {
        var serviceResponse = new ServiceResponse<List<StudentResult>>();

        try
        {
            var students = await dbContext.Students
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
            }

            serviceResponse.Data = studentsMapped;
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
            var student = await GetById(dbContext, id);

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
            var student = new StudentType
            {
                FirstName = newStudent.FirstName,
                LastName = newStudent.LastName,
                Gpa = newStudent.Gpa
            };

            await dbContext.AddAsync(student);
            await dbContext.SaveChangesAsync();

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
            var student = await dbContext.Students.FindAsync(id);

            if (student is null)
                throw new GraphQLException(new Error("Student not found!", "STUDENT_NOT_FOUND"));

            // Update data and save (manual map)
            student.FirstName = updatedStudent.FirstName;
            student.LastName = updatedStudent.LastName;
            student.Gpa = updatedStudent.Gpa;

            await dbContext.SaveChangesAsync();

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
            var student = await dbContext.Students.FindAsync(id);

            if (student is null)
                throw new GraphQLException(new Error("Course not found!", "COURSE_NOT_FOUND"));

            dbContext.Students.Remove(student);
            await dbContext.SaveChangesAsync();
        }

        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }
}