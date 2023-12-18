using GraphQLDemo.API.DTOs.Instructor;
using GraphQLDemo.API.Entities;
using GraphQLDemo.API.Interfaces;

namespace GraphQLDemo.API.Infrastructure.Repository;

public class InstructorRepository : IInstructorRepository
{
    private readonly Func<AppDbContext, Guid, Task<InstructorResult?>> GetById =
        EF.CompileAsyncQuery((AppDbContext context, Guid id) =>
            context.Instructors
                .Select(i => new InstructorResult()
                {
                    Id = i.Id,
                    FirstName = i.FirstName,
                    LastName = i.LastName,
                    Salary = i.Salary,
                    CourseId = i.CourseId
                })
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id));

    private readonly AppDbContext _dbContext;

    public InstructorRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ServiceResponse<List<InstructorResult>>> GetAllInstructorsAsync()
    {
        var serviceResponse = new ServiceResponse<List<InstructorResult>>();

        try
        {
            var instructors = await _dbContext.Instructors
                .AsNoTracking()
                .ToListAsync();

            var instructorsMapped = new List<InstructorResult>();

            foreach (var instructor in instructors)
            {
                var instructorResult = new InstructorResult
                {
                    Id = instructor.Id,
                    FirstName = instructor.FirstName,
                    LastName = instructor.LastName,
                    Salary = instructor.Salary,
                    CourseId = instructor.CourseId
                };

                instructorsMapped.Add(instructorResult);
                serviceResponse.Data = instructorsMapped;
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<InstructorResult>> GetInstructorByIdAsync(Guid id)
    {
        var serviceResponse = new ServiceResponse<InstructorResult>();

        try
        {
            var instructor = await GetById(_dbContext, id);

            if (instructor is null)
                throw new GraphQLException(new Error("Instructor not found!", "INSTRUCTOR_NOT_FOUND"));

            serviceResponse.Data = instructor;
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<InstructorResult>> AddInstructorAsync(InstructorInput newInstructor)
    {
        var serviceResponse = new ServiceResponse<InstructorResult>();

        try
        {
            var instructor = new InstructorType
            {
                FirstName = newInstructor.FirstName,
                LastName = newInstructor.LastName,
                Salary = newInstructor.Salary,
                CourseId = newInstructor.CourseId
            };

            await _dbContext.Instructors.AddAsync(instructor);
            await _dbContext.SaveChangesAsync();

            var instructorResult = new InstructorResult
            {
                Id = instructor.Id,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                Salary = instructor.Salary,
                CourseId = instructor.CourseId
            };

            serviceResponse.Data = instructorResult;

            return serviceResponse;
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<InstructorResult>> UpdateInstructorAsync(Guid id,
        InstructorInput updatedInstructor)
    {
        var serviceResponse = new ServiceResponse<InstructorResult>();

        try
        {
            var instructor = await _dbContext.Instructors.FindAsync(id);

            if (instructor is null)
                throw new GraphQLException(new Error("Instructor not found!", "INSTRUCTOR_NOT_FOUND"));

            instructor.FirstName = updatedInstructor.FirstName;
            instructor.LastName = updatedInstructor.LastName;
            instructor.Salary = updatedInstructor.Salary;
            instructor.CourseId = updatedInstructor.CourseId;

            await _dbContext.SaveChangesAsync();

            var instructorResult = new InstructorResult
            {
                Id = instructor.Id,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                Salary = instructor.Salary,
                CourseId = instructor.CourseId
            };

            serviceResponse.Data = instructorResult;
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<bool>> RemoveInstructor(Guid id)
    {
        var serviceResponse = new ServiceResponse<bool>();

        try
        {
            var instructor = await _dbContext.Instructors.FindAsync(id);

            if (instructor is null)
                throw new GraphQLException(new Error("Instructor not found!", "INSTRUCTOR_NOT_FOUND"));

            _dbContext.Instructors.Remove(instructor);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }
}