using FluentValidation;
using WC.Library.Employee.Shared.Validators;
using WC.Service.Employees.Domain.Models;
using WC.Service.Employees.Domain.Services.Position.Validators;

namespace WC.Service.Employees.Domain.Services.Employee.Validators;

public sealed class EmployeeModelValidator : AbstractValidator<EmployeeModel>
{
    public EmployeeModelValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .SetValidator(new NameValidator(nameof(EmployeeModel.Name)));

        RuleFor(x => x.Surname)
            .NotNull()
            .SetValidator(new NameValidator(nameof(EmployeeModel.Surname)));

        RuleFor(x => x.Patronymic)
            .NotNull()
            .SetValidator(new NameValidator(nameof(EmployeeModel.Patronymic))!)
            .When(x => x != null);

        RuleFor(x => x.Position)
            .NotNull()
            .SetValidator(new PositionModelValidator());
    }
}
