using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WC.Library.Domain.Validators;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.Domain.Services.Employee.Validators;

public sealed class EmployeeUpdateValidator
    : AbstractValidator<EmployeeModel>,
        IDomainUpdateValidator
{
    public EmployeeUpdateValidator(
        IServiceProvider provider)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x)
            .SetValidator(provider.GetService<EmployeeModelValidator>());
    }
}
