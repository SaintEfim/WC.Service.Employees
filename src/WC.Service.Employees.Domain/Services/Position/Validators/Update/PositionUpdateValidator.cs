using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WC.Library.Domain.Validators;
using WC.Service.Employees.Domain.Models;
using WC.Service.Employees.Domain.Services.Position.Validators.Create;

namespace WC.Service.Employees.Domain.Services.Position.Validators.Update;

public sealed class PositionUpdateValidator
    : AbstractValidator<PositionModel>,
        IDomainUpdateValidator
{
    public PositionUpdateValidator(
        IServiceProvider provider)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x)
            .SetValidator(provider.GetService<PositionModelValidator>());

        RuleFor(x => x)
            .SetValidator(provider.GetService<PositionCreateDbValidator>());
    }
}
