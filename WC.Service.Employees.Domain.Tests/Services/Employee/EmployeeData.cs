using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.Domain.Tests.Services.Employee;

public static class EmployeeData
{
    public static readonly Func<EmployeeModel> EmployeeModel = () => new EmployeeModel
    {
        Name = "Админ",
        Surname = "Админов",
        Patronymic = "Админович",
        Email = "email@email.com",
        PositionId = Guid.Parse("00000000-0000-0000-0000-000000000001")
    };
}
