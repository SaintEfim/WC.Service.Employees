using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WC.Library.Domain.Validators;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.Domain.Services.Position.Validators.Create;

public sealed class PositionCreateValidator
    : AbstractValidator<PositionModel>,
        IDomainCreateValidator
{
    public PositionCreateValidator(
        IServiceProvider provider)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x)
            .SetValidator(provider.GetService<PositionModelValidator>());

        RuleFor(x => x)
            .SetValidator(provider.GetService<PositionCreateDbValidator>());
    }
}
