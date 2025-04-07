using FluentValidation;
using FluentValidation.TestHelper;
using WC.Service.Employees.Domain.Models;
using WC.Service.Employees.Domain.Services.Position.Validators;

namespace WC.Service.Employees.Domain.Tests.Services.Position.Validators;

public class PositionModelValidatorTests
{
    private static async Task Check_Main_Data(
        Func<PositionModel> newModelFunc,
        Action<TestValidationResult<PositionModel>> checkResult)
    {
        var validator = new PositionModelValidator();
        var context = new ValidationContext<PositionModel>(newModelFunc());
        var result = await validator.TestValidateAsync(context);
        checkResult(result);
    }

    [Fact]
    public Task PositionModel_Positive_Model_Validator()
    {
        return Check_Main_Data(NewModelFunc,
            r => r.ShouldNotHaveAnyValidationErrors());

        PositionModel NewModelFunc()
        {
            return PositionData.PositionModel();
        }
    }

    [Fact]
    public Task PositionModel_Negative_Name_Empty()
    {
        return Check_Main_Data(NewModelFunc,
            r => r.ShouldHaveAnyValidationError()
                .WithErrorCode("NotEmptyValidator")
                .When(x => x.PropertyName == "Name." + nameof(PositionModel.Name))
                .Only());

        PositionModel NewModelFunc()
        {
            var data = PositionData.PositionModel();
            data.Name = "";
            return data;
        }
    }

    [Fact]
    public Task PositionModel_Negative_Name_TooShort()
    {
        return Check_Main_Data(NewModelFunc,
            r => r.ShouldHaveAnyValidationError()
                .WithErrorCode("MinimumLengthValidator")
                .When(x => x.PropertyName == "Name." + nameof(PositionModel.Name))
                .Only());

        PositionModel NewModelFunc()
        {
            var data = PositionData.PositionModel();
            data.Name = "П";
            return data;
        }
    }

    [Fact]
    public Task PositionModel_Negative_Name_TooLong()
    {
        return Check_Main_Data(NewModelFunc,
            r => r.ShouldHaveAnyValidationError()
                .WithErrorCode("MaximumLengthValidator")
                .When(x => x.PropertyName == "Name." + nameof(PositionModel.Name))
                .Only());

        PositionModel NewModelFunc()
        {
            var data = PositionData.PositionModel();
            data.Name = new string('П',
                101);
            return data;
        }
    }

    [Fact]
    public Task PositionModel_Negative_Name_InvalidFormat()
    {
        return Check_Main_Data(NewModelFunc,
            r => r.ShouldHaveAnyValidationError()
                .WithErrorCode("RegularExpressionValidator")
                .When(x => x.PropertyName == "Name." + nameof(PositionModel.Name))
                .Only());

        PositionModel NewModelFunc()
        {
            var data = PositionData.PositionModel();
            data.Name = "программист";
            return data;
        }
    }

    [Fact]
    public Task PositionModel_Negative_Name_Is_Not_Cyrillic()
    {
        return Check_Main_Data(NewModelFunc,
            r => r.ShouldHaveAnyValidationError()
                .WithErrorCode("RegularExpressionValidator")
                .When(x => x.PropertyName == "Name." + nameof(PositionModel.Name))
                .Only());

        PositionModel NewModelFunc()
        {
            var data = PositionData.PositionModel();
            data.Name = "Programmer";
            return data;
        }
    }
}
