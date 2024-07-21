using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WC.Library.Domain.Validators;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.Domain.Services.Employee.Validators;

public sealed class EmployeeCreateValidator
    : AbstractValidator<EmployeeModel>,
        IDomainCreateValidator
{
    public EmployeeCreateValidator(
        IServiceProvider provider)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x)
            .SetValidator(provider.GetService<EmployeeModelValidator>());
    }
}
