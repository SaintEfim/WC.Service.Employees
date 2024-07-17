using FluentValidation;
using WC.Library.Domain.Validators;
using WC.Library.Employee.Shared.Validators;
using WC.Service.Employees.Domain.Models;
using WC.Service.Employees.Domain.Services.Colleague.Validators;
using WC.Service.Employees.Domain.Services.Position.Validators;

namespace WC.Service.Employees.Domain.Services.Employee.Validators;

public sealed class EmployeeUpdateValidator : AbstractValidator<EmployeeModel>, IDomainUpdateValidator
{
    public EmployeeUpdateValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .SetValidator(new NameValidator(nameof(EmployeeModel.Name)));

        RuleFor(x => x.Surname)
            .NotNull()
            .SetValidator(new NameValidator(nameof(EmployeeModel.Surname)));

        RuleFor(x => x.Patronymic)
            .SetValidator(new NameValidator(nameof(EmployeeModel.Patronymic))!)
            .When(x => !string.IsNullOrEmpty(x.Patronymic));

        RuleFor(x => x.Email)
            .NotNull()
            .SetValidator(new EmailValidator(nameof(EmployeeModel.Email)));

        RuleFor(x => x.Password)
            .NotNull()
            .SetValidator(new PasswordValidator(nameof(EmployeeModel.Password)));

        RuleFor(x => x.Position)
            .NotNull()
            .SetValidator(new PositionModelValidator());

        RuleForEach(x => x.Colleagues)
            .NotNull()
            .SetValidator(new ColleagueModelValidator());
    }
}