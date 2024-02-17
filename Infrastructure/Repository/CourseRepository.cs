using GraphQLDemo.API.DTOs.Course;
using GraphQLDemo.API.Entities;
using GraphQLDemo.API.Interfaces;

namespace GraphQLDemo.API.Infrastructure.Repository;

public class CourseRepository(AppDbContext dbContext) : ICourseRepository
{
    private readonly Func<AppDbContext, Guid, Task<CourseResult?>> GetById =
        EF.CompileAsyncQuery((AppDbContext context, Guid id) =>
            context.Courses
                .Select(c => new CourseResult
                {
                    Id = c.Id,
                    Name = c.Name,
                    Subject = c.Subject,
                    InstructorId = c.InstructorId
                })
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id));

    public async Task<ServiceResponse<List<CourseResult>>> GetAllCoursesAsync()
    {
        var serviceResponse = new ServiceResponse<List<CourseResult>>();

        try
        {
            var courses = await dbContext.Courses
                .AsNoTracking()
                .ToListAsync();

            var coursesMapped = new List<CourseResult>();

            foreach (var course in courses)
            {
                var courseResult = new CourseResult
                {
                    Id = course.Id,
                    Name = course.Name,
                    Subject = course.Subject,
                    InstructorId = course.InstructorId
                };

                coursesMapped.Add(courseResult);
            }

            serviceResponse.Data = coursesMapped;
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<CourseResult>> GetCourseByIdAsync(Guid id)
    {
        var serviceResponse = new ServiceResponse<CourseResult>();

        try
        {
            var course = await GetById(dbContext, id);

            if (course is null) throw new GraphQLException(new Error("Course not found!", "COURSE_NOT_FOUND"));

            serviceResponse.Data = course;
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<CourseResult>> AddCourseAsync(CourseInput newCourse)
    {
        var serviceResponse = new ServiceResponse<CourseResult>();

        try
        {
            var course = new CourseType
            {
                Name = newCourse.Name,
                Subject = newCourse.Subject,
                InstructorId = newCourse.InstructorId
            };

            await dbContext.AddAsync(course);
            await dbContext.SaveChangesAsync();

            var courseResult = new CourseResult
            {
                Id = course.Id,
                Name = course.Name,
                Subject = course.Subject,
                InstructorId = course.InstructorId
            };

            serviceResponse.Data = courseResult;
        }

        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<CourseResult>> UpdateCourseAsync(Guid id, CourseInput updatedCourse)
    {
        var serviceResponse = new ServiceResponse<CourseResult>();

        try
        {
            var course = await dbContext.Courses.FindAsync(id);

            if (course is null)
                throw new GraphQLException(new Error("Course not found!", "COURSE_NOT_FOUND"));

            course.Name = updatedCourse.Name;
            course.Subject = updatedCourse.Subject;
            course.InstructorId = updatedCourse.InstructorId;

            await dbContext.SaveChangesAsync();

            var courseResult = new CourseResult
            {
                Id = course.Id,
                Name = course.Name,
                Subject = course.Subject,
                InstructorId = course.InstructorId
            };

            serviceResponse.Data = courseResult;
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<bool>> RemoveCourseAsync(Guid id)
    {
        var serviceResponse = new ServiceResponse<bool>();

        try
        {
            var course = await dbContext.Courses.FindAsync(id);

            if (course is null)
                throw new GraphQLException(new Error("Course not found!", "COURSE_NOT_FOUND"));

            dbContext.Courses.Remove(course);
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