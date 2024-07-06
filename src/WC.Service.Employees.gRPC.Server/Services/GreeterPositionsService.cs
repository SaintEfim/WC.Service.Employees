using Grpc.Core;
using WC.Service.Employees.Domain.Services.Position;

namespace WC.Service.Employees.gRPC.Server.Services;

public class GreeterPositionsService : GreeterPositions.GreeterPositionsBase
{
    private readonly IPositionProvider _provider;

    public GreeterPositionsService(IPositionProvider provider)
    {
        _provider = provider;
    }

    public override async Task<SearchPositionResponse> SearchPosition(SearchPositionRequest request,
        ServerCallContext context)
    {
        var position = await _provider.SearchPosition(request.Position.Name);

        if (position == null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, "Position not found"));
        }

        return new SearchPositionResponse
        {
            Id = position.Id.ToString(),
            Name = position.Name,
            Description = position.Description
        };
    }
}