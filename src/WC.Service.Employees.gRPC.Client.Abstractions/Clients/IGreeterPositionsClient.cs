using WC.Service.Employees.gRPC.Client.Models.Position;

namespace WC.Service.Employees.gRPC.Client.Clients;

public interface IGreeterPositionsClient
{
    Task<GetOneByNamePositionResponseModel> GetOneByName(
        GetOneByNamePositionRequestModel request,
        CancellationToken cancellationToken = default);
}
