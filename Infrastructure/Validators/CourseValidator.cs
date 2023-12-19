using FluentValidation;
using GraphQLDemo.API.DTOs.Course;
using GraphQLDemo.API.Entities;

namespace GraphQLDemo.API.Infrastructure.Validators;

public class CourseValidator : AbstractValidator<CourseInput>
{
    public CourseValidator()
    {
        RuleFor(c => c.Name)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Name can not be null!")
            .NotEmpty().WithMessage("Name can not be empty!")
            .Length(2, 100).WithMessage("Name must be at least 2 characters and a maximum of 100 characters!");

        RuleFor(c => c.Subject)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Subject can not be null!")
            .NotEmpty().WithMessage("Subject can not be empty!")
            .Must(subject => subject is Subject.History or Subject.Mathematics or Subject.Science)
            .WithMessage("Subject must \"History\", \"Mathematics\" or \"Science\"!");

        RuleFor(c => c.InstructorId)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("InstructorId can not be null!")
            .NotEmpty().WithMessage("InstructorId can not be empty!");
    }
}