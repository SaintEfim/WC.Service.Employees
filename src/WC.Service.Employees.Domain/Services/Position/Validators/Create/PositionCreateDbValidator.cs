using FluentValidation;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.Domain.Services.Position.Validators.Create;

public sealed class PositionCreateDbValidator : AbstractValidator<PositionModel>
{
    public PositionCreateDbValidator(IPositionProvider positionProvider)
    {
        RuleFor(x => x)
            .CustomAsync(async (positionModel, context, cancellationToken) =>
            {
                var positions = await positionProvider.Get(cancellationToken: cancellationToken);

                var duplicatePosition = positions.Any(x => x.Name == positionModel.Name);

                if (duplicatePosition)
                    context.AddFailure(nameof(PositionModel.Name),
                        $"Position with this {positionModel.Name} already exists.");
            });
    }
}