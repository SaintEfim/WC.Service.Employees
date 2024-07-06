using WC.Service.Employees.gRPC.Client.Models.Position;

namespace WC.Service.Employees.gRPC.Client.Clients;

public interface IGreeterPositionsClient
{
    Task<SearchPositionResponseModel> SearchPosition(SearchPositionRequestModel request,
        CancellationToken cancellationToken = default);
}