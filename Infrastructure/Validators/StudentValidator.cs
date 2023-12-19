using FluentValidation;
using GraphQLDemo.API.DTOs.Student;

namespace GraphQLDemo.API.Infrastructure.Validators;

public class StudentValidator : AbstractValidator<StudentInput>
{
    public StudentValidator()
    {
        RuleFor(s => s.FirstName)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("First Name can not be null!")
            .NotEmpty().WithMessage("First Name can not be empty!")
            .Length(2, 100).WithMessage("First Name must be at least 2 characters and a maximum of 100 characters!");

        RuleFor(s => s.LastName)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Last Name can not be null!")
            .NotEmpty().WithMessage("Last Name can not be empty!")
            .Length(2, 100).WithMessage("First Name must be at least 2 characters and a maximum of 100 characters!");

        RuleFor(s => s.Gpa)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("GPA can not be null!")
            .NotEmpty().WithMessage("GPA can not be empty!")
            .Must(gpa => gpa is >= 0 and <= 4.0);
    }
}