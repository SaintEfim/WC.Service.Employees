using WC.Service.Employees.Data.Models;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.Domain.Tests.Services.Position;

public static class PositionData
{
    public static readonly Func<PositionModel> PositionModel = () => new PositionModel { Name = "Программист" };

    public static readonly Func<PositionEntity> PositionEntity = () => new PositionEntity { Name = "Программист" };
}
