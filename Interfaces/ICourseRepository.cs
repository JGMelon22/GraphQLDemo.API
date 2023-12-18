using GraphQLDemo.API.DTOs.Course;
using GraphQLDemo.API.Entities;

namespace GraphQLDemo.API.Interfaces;

public interface ICourseRepository
{
    Task<ServiceResponse<List<CourseResult>>> GetAllCoursesAsync();
    Task<ServiceResponse<CourseResult>> GetCourseByIdAsync(Guid id);
    Task<ServiceResponse<CourseResult>> AddCourseAsync(CourseInput newCourse);
    Task<ServiceResponse<CourseResult>> UpdateCourseAsync(Guid id, CourseInput updatedCourse);
    Task<bool> RemoveCourse(Guid id);
}