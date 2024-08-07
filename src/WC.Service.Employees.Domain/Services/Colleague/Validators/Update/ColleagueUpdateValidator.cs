using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WC.Library.Domain.Validators;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.Domain.Services.Colleague.Validators.Update;

public sealed class ColleagueUpdateValidator
    : AbstractValidator<ColleagueModel>,
        IDomainUpdateValidator
{
    public ColleagueUpdateValidator(
        IServiceProvider provider)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x)
            .SetValidator(provider.GetService<ColleagueModelValidator>());

        RuleFor(x => x)
            .SetValidator(provider.GetService<ColleagueUpdateDbValidator>());
    }
}
