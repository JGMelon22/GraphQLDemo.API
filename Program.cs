using GraphQLDemo.API.GraphQL.Mutations;
using GraphQLDemo.API.GraphQL.Types;
using GraphQLDemo.API.Infrastructure.Repository;
using GraphQLDemo.API.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// DbContext service
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Interfaces & Repositories
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

builder.Services.AddGraphQLServer()
    .AddQueryType<StudentQueryTypes>()
    .AddMutationType<StudentMutationType>();

var app = builder.Build();

app.MapGraphQL();

app.Run();