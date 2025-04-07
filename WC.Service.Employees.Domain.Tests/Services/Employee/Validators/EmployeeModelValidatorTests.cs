using FluentValidation;
using FluentValidation.TestHelper;
using WC.Service.Employees.Domain.Models;
using WC.Service.Employees.Domain.Services.Employee.Validators;

namespace WC.Service.Employees.Domain.Tests.Services.Employee.Validators;

public class EmployeeModelValidatorTests
{
    private static async Task Check_Main_Data(
        Func<EmployeeModel> newModelFunc,
        Action<TestValidationResult<EmployeeModel>> checkResult)
    {
        var validator = new EmployeeModelValidator();
        var context = new ValidationContext<EmployeeModel>(newModelFunc());
        var result = await validator.TestValidateAsync(context);
        checkResult(result);
    }

    [Fact]
    public Task EmployeeModel_Positive_Model_Validator()
    {
        return Check_Main_Data(NewModelFunc,
            r => r.ShouldNotHaveAnyValidationErrors());

        EmployeeModel NewModelFunc()
        {
            return EmployeeData.EmployeeModel();
        }
    }

    [Fact]
    public Task EmployeeModel_Negative_Name_Empty()
    {
        return Check_Main_Data(NewModelFunc,
            r => r.ShouldHaveAnyValidationError()
                .WithErrorCode("NotEmptyValidator")
                .When(x => x.PropertyName == "Name." + nameof(EmployeeModel.Name))
                .Only());

        EmployeeModel NewModelFunc()
        {
            var data = EmployeeData.EmployeeModel();
            data.Name = "";
            return data;
        }
    }

    [Fact]
    public Task EmployeeModel_Negative_Name_TooShort()
    {
        return Check_Main_Data(NewModelFunc,
            r => r.ShouldHaveAnyValidationError()
                .WithErrorCode("MinimumLengthValidator")
                .When(x => x.PropertyName == "Name." + nameof(EmployeeModel.Name))
                .Only());

        EmployeeModel NewModelFunc()
        {
            var data = EmployeeData.EmployeeModel();
            data.Name = "А";
            return data;
        }
    }

    [Fact]
    public Task EmployeeModel_Negative_Name_TooLong()
    {
        return Check_Main_Data(NewModelFunc,
            r => r.ShouldHaveAnyValidationError()
                .WithErrorCode("MaximumLengthValidator")
                .When(x => x.PropertyName == "Name." + nameof(EmployeeModel.Name))
                .Only());

        EmployeeModel NewModelFunc()
        {
            var data = EmployeeData.EmployeeModel();
            data.Name = new string('А',
                51);
            return data;
        }
    }

    [Fact]
    public Task EmployeeModel_Negative_Name_InvalidFormat()
    {
        return Check_Main_Data(NewModelFunc,
            r => r.ShouldHaveAnyValidationError()
                .WithErrorMessage(
                    $"{nameof(EmployeeModel.Name)} must start with an uppercase letter followed by lowercase letters, all in Cyrillic.")
                .When(x => x.PropertyName == "Name." + nameof(EmployeeModel.Name))
                .Only());

        EmployeeModel NewModelFunc()
        {
            var data = EmployeeData.EmployeeModel();
            data.Name = "admin";
            return data;
        }
    }

    [Fact]
    public Task EmployeeModel_Negative_Surname_Empty()
    {
        return Check_Main_Data(NewModelFunc,
            r => r.ShouldHaveAnyValidationError()
                .WithErrorCode("NotEmptyValidator")
                .When(x => x.PropertyName == "Surname." + nameof(EmployeeModel.Surname))
                .Only());

        EmployeeModel NewModelFunc()
        {
            var data = EmployeeData.EmployeeModel();
            data.Surname = "";
            return data;
        }
    }

    [Fact]
    public Task EmployeeModel_Negative_Surname_TooShort()
    {
        return Check_Main_Data(NewModelFunc,
            r => r.ShouldHaveAnyValidationError()
                .WithErrorCode("MinimumLengthValidator")
                .When(x => x.PropertyName == "Surname." + nameof(EmployeeModel.Surname))
                .Only());

        EmployeeModel NewModelFunc()
        {
            var data = EmployeeData.EmployeeModel();
            data.Surname = "А";
            return data;
        }
    }

    [Fact]
    public Task EmployeeModel_Negative_Surname_TooLong()
    {
        return Check_Main_Data(NewModelFunc,
            r => r.ShouldHaveAnyValidationError()
                .WithErrorCode("MaximumLengthValidator")
                .When(x => x.PropertyName == "Surname." + nameof(EmployeeModel.Surname))
                .Only());

        EmployeeModel NewModelFunc()
        {
            var data = EmployeeData.EmployeeModel();
            data.Surname = new string('А',
                51);
            return data;
        }
    }

    [Fact]
    public Task EmployeeModel_Negative_Surname_InvalidFormat()
    {
        return Check_Main_Data(NewModelFunc,
            r => r.ShouldHaveAnyValidationError()
                .WithErrorMessage(
                    $"{nameof(EmployeeModel.Surname)} must start with an uppercase letter followed by lowercase letters, all in Cyrillic.")
                .When(x => x.PropertyName == "Surname." + nameof(EmployeeModel.Surname))
                .Only());

        EmployeeModel NewModelFunc()
        {
            var data = EmployeeData.EmployeeModel();
            data.Surname = "adminov";
            return data;
        }
    }

    [Fact]
    public Task EmployeeModel_Negative_Patronymic_TooShort()
    {
        return Check_Main_Data(NewModelFunc,
            r => r.ShouldHaveAnyValidationError()
                .WithErrorCode("MinimumLengthValidator")
                .When(x => x.PropertyName == "Patronymic." + nameof(EmployeeModel.Patronymic))
                .Only());

        EmployeeModel NewModelFunc()
        {
            var data = EmployeeData.EmployeeModel();
            data.Patronymic = "А";
            return data;
        }
    }

    [Fact]
    public Task EmployeeModel_Negative_Patronymic_TooLong()
    {
        return Check_Main_Data(NewModelFunc,
            r => r.ShouldHaveAnyValidationError()
                .WithErrorCode("MaximumLengthValidator")
                .When(x => x.PropertyName == "Patronymic." + nameof(EmployeeModel.Patronymic))
                .Only());

        EmployeeModel NewModelFunc()
        {
            var data = EmployeeData.EmployeeModel();
            data.Patronymic = new string('А',
                51);
            return data;
        }
    }

    [Fact]
    public Task EmployeeModel_Negative_Patronymic_InvalidFormat()
    {
        return Check_Main_Data(NewModelFunc,
            r => r.ShouldHaveAnyValidationError()
                .WithErrorMessage(
                    $"{nameof(EmployeeModel.Patronymic)} must start with an uppercase letter followed by lowercase letters, all in Cyrillic.")
                .When(x => x.PropertyName == "Patronymic." + nameof(EmployeeModel.Patronymic))
                .Only());

        EmployeeModel NewModelFunc()
        {
            var data = EmployeeData.EmployeeModel();
            data.Patronymic = "patronymic";
            return data;
        }
    }

    [Fact]
    public Task EmployeeModel_Negative_PositionId_Empty()
    {
        return Check_Main_Data(NewModelFunc,
            r => r.ShouldHaveAnyValidationError()
                .WithErrorCode("NotEmptyValidator")
                .When(x => x.PropertyName == nameof(EmployeeModel.PositionId))
                .Only());

        EmployeeModel NewModelFunc()
        {
            var data = EmployeeData.EmployeeModel();
            data.PositionId = Guid.Empty;
            return data;
        }
    }
}
