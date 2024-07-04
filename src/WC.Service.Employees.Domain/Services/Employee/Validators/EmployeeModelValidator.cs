using FluentValidation;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.Domain.Services.Employee.Validators;

public class EmployeeModelValidator : AbstractValidator<EmployeeModel>
{
    public EmployeeModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Surname)
            .NotEmpty();

        RuleFor(x => x.Patronymic)
            .NotEmpty()
            .When(x => !string.IsNullOrEmpty(x.Patronymic));

        RuleFor(x => x.Email)
            .NotEmpty();

        RuleFor(x => x.Password)
            .NotEmpty();

        RuleFor(x => x.PositionId)
            .NotEmpty();
    }
}