using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WC.Library.Domain.Validators;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.Domain.Services.Colleague.Validators.Create;

public sealed class ColleagueCreateValidator : AbstractValidator<ColleagueModel>, IDomainCreateValidator
{
    public ColleagueCreateValidator(IServiceProvider provider)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x)
            .SetValidator(provider.GetService<ColleagueModelValidator>());

        RuleFor(x => x)
            .SetValidator(provider.GetService<ColleagueCreateDbValidator>());
    }
}