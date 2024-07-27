using FluentValidation;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.Domain.Services.Employee.Validators;

public sealed class EmployeeModelValidator : AbstractValidator<EmployeeModel>
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
    }
}
