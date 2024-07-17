using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WC.Library.Domain.Validators;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.Domain.Services.Position.Validators;

public sealed class PositionUpdateValidator : AbstractValidator<PositionModel>, IDomainUpdateValidator
{
    public PositionUpdateValidator(IServiceProvider provider)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x)
            .SetValidator(provider.GetService<PositionModelValidator>());
    }
}