using FluentValidation;
using WC.Library.Shared.Exceptions;
using WC.Service.Employees.Domain.Models;
using WC.Service.Employees.Domain.Services.Employee;

namespace WC.Service.Employees.Domain.Services.Colleague.Validators.Update;

public sealed class ColleagueUpdateDbValidator : AbstractValidator<ColleagueModel>
{
    public ColleagueUpdateDbValidator(
        IEmployeeProvider provider)
    {
        RuleFor(x => x.EmployeeId)
            .MustAsync(async (
                employeeId,
                cancellationToken) => await EmployeeExists(employeeId, provider, cancellationToken))
            .WithMessage("The employee does not exist.");

        RuleFor(x => x.ColleagueEmployeeId)
            .MustAsync(async (
                colleagueEmployeeId,
                cancellationToken) => await EmployeeExists(colleagueEmployeeId, provider, cancellationToken))
            .WithMessage("The colleague employee does not exist.");
    }

    private static async Task<bool> EmployeeExists(
        Guid employeeId,
        IEmployeeProvider provider,
        CancellationToken cancellationToken)
    {
        try
        {
            var employee = await provider.GetOneById(employeeId, cancellationToken: cancellationToken);
            return employee != null;
        }
        catch (NotFoundException)
        {
            return false;
        }
    }
}
