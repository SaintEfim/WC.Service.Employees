using WC.Library.Domain.Services;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.Domain.Services.Position;

public interface IPositionProvider : IDataProvider<PositionModel>
{
    Task<PositionModel?> GetOneByName(
        string positionName,
        CancellationToken cancellationToken = default);
}
