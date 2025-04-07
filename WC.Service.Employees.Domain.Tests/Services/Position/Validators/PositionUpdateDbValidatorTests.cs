using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.TestHelper;
using Moq;
using WC.Library.Data.Services;
using WC.Service.Employees.Data.Models;
using WC.Service.Employees.Data.Repositories;
using WC.Service.Employees.Domain.Models;
using WC.Service.Employees.Domain.Services.Position.Validators.Update;

namespace WC.Service.Employees.Domain.Tests.Services.Position.Validators;

public class PositionUpdateDbValidatorTests
{
    private static PositionUpdateDbValidator GetValidator(
        IMock<IPositionRepository> repository)
    {
        var builder = new ContainerBuilder();
        builder.RegisterInstance(repository.Object);
        builder.RegisterType<PositionUpdateDbValidator>();
        builder.Populate([]);
        var container = builder.Build();
        return container.Resolve<PositionUpdateDbValidator>();
    }

    [Fact]
    public async Task Position_Positive_Update_New_Record()
    {
        var position = PositionData.PositionModel();

        var repository = new Mock<IPositionRepository>(MockBehavior.Strict);
        repository.Setup(x => x.Get(default,
                default,
                It.IsAny<IWcTransaction>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<PositionEntity>())
            .Verifiable();

        var validator = GetValidator(repository);

        var result = await validator.TestValidateAsync(position);

        result.ShouldNotHaveAnyValidationErrors();

        repository.Verify();
    }

    [Fact]
    public async Task Position_Negative_Update_New_Record_Has_Duplicate()
    {
        var position = PositionData.PositionModel();
        var positionEntity = PositionData.PositionEntity();

        var repository = new Mock<IPositionRepository>(MockBehavior.Strict);
        repository.Setup(x => x.Get(default,
                default,
                It.IsAny<IWcTransaction>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<PositionEntity> { positionEntity })
            .Verifiable();

        var validator = GetValidator(repository);

        var result = await validator.TestValidateAsync(position);

        result.ShouldHaveAnyValidationError()
            .WithErrorMessage($"Position with this {position.Name} already exists.")
            .When(x => x.PropertyName == nameof(PositionModel.Name));

        repository.Verify();
    }
}
