using FluentValidation;
using GraphQLDemo.API.DTOs.Course;
using GraphQLDemo.API.DTOs.Instructor;
using GraphQLDemo.API.DTOs.Student;
using GraphQLDemo.API.GraphQL.Mutations;
using GraphQLDemo.API.GraphQL.Types;
using GraphQLDemo.API.Infrastructure.Repository;
using GraphQLDemo.API.Infrastructure.Validators;
using GraphQLDemo.API.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// DbContext service
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Interfaces & Repositories
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

// FluentValidation
builder.Services.AddTransient<IValidator<StudentInput>, StudentValidator>();
builder.Services.AddTransient<IValidator<InstructorInput>, InstructorValidator>();
builder.Services.AddTransient<IValidator<CourseInput>, CourseValidator>();

builder.Services.AddGraphQLServer()
    .AddQueryType<QueryTypes>()
    .AddMutationType<MutationType>();

var app = builder.Build();

app.MapGraphQL();

app.Run();