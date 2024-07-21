using FluentValidation;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.Domain.Services.Colleague.Validators;

public sealed class ColleagueModelValidator : AbstractValidator<ColleagueModel>
{
    public ColleagueModelValidator()
    {
        RuleFor(x => x.EmployeeId)
            .NotEqual(x => x.ColleagueEmployeeId);
    }
}
