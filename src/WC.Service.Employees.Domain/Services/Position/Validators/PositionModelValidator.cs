using FluentValidation;
using WC.Library.Employee.Shared.Validators;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.Domain.Services.Position.Validators;

public sealed class PositionModelValidator : AbstractValidator<PositionModel>
{
    public PositionModelValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .SetValidator(new PositionValidator(nameof(PositionModel.Name)));
    }
}
