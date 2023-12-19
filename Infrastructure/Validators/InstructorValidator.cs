using FluentValidation;
using GraphQLDemo.API.DTOs.Instructor;

namespace GraphQLDemo.API.Infrastructure.Validators;

public class InstructorValidator : AbstractValidator<InstructorInput>
{
    public InstructorValidator()
    {
        Decimal minimumSalary = 2000.00M;
        Decimal maximumSalary = 9999999.99M;

        RuleFor(i => i.FirstName)
            .NotNull().WithMessage("First Name can not be null!")
            .NotEmpty().WithMessage("First Name can not be empty!")
            .Length(2, 100).WithMessage("First Name must be at least 2 characters and a maximum of 100 characters!");

        RuleFor(i => i.LastName)
            .NotNull().WithMessage("Last Name can not be null!")
            .NotEmpty().WithMessage("Last Name can not be empty!")
            .Length(2, 100).WithMessage("First Name must be at least 2 characters and a maximum of 100 characters!");

        RuleFor(i => i.Salary)
            .NotNull().WithMessage("Salary can not be null!")
            .NotEmpty().WithMessage("Salary can not be empty!")
            .Must(salary => salary is >= 2000.00M and <= 9999999.99M).WithMessage(
                $"Instructor salary must be at least {minimumSalary:c2} and maximum of {maximumSalary:c2}!");

        RuleFor(i => i.CourseId)
            .NotNull().WithMessage("CourseId can not be null!")
            .NotEmpty().WithMessage("CourseId can not be empty!");
    }
}