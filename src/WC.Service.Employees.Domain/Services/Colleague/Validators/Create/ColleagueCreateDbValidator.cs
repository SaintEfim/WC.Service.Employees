using FluentValidation;
using WC.Library.Data.Services;
using WC.Library.Shared.Exceptions;
using WC.Service.Employees.Domain.Models;
using WC.Service.Employees.Domain.Services.Employee;

namespace WC.Service.Employees.Domain.Services.Colleague.Validators.Create;

public sealed class ColleagueCreateDbValidator : AbstractValidator<ColleagueModel>
{
    public ColleagueCreateDbValidator(
        IEmployeeProvider provider)
    {
        RuleFor(x => x.EmployeeId)
            .MustAsync(async (
                employeeId,
                cancellationToken) => await EmployeeExists(employeeId, provider, cancellationToken: cancellationToken))
            .WithMessage("The employee does not exist.");

        RuleFor(x => x.ColleagueEmployeeId)
            .MustAsync(async (
                    colleagueEmployeeId,
                    cancellationToken) =>
                await EmployeeExists(colleagueEmployeeId, provider, cancellationToken: cancellationToken))
            .WithMessage("The colleague employee does not exist.");
    }

    private static async Task<bool> EmployeeExists(
        Guid employeeId,
        IEmployeeProvider provider,
        IWcTransaction? transaction = default,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var employee = await provider.GetOneById(employeeId, transaction: transaction,
                cancellationToken: cancellationToken);
            return employee != null;
        }
        catch (NotFoundException)
        {
            return false;
        }
    }
}
