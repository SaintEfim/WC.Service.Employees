using Grpc.Core;
using WC.Service.Employees.Domain.Services.Position;

namespace WC.Service.Employees.gRPC.Server.Services;

public class GreeterPositionsService : GreeterPositions.GreeterPositionsBase
{
    private readonly IPositionProvider _provider;

    public GreeterPositionsService(
        IPositionProvider provider)
    {
        _provider = provider;
    }

    public override async Task<GetOneByNamePositionResponse> GetOneByName(
        GetOneByNamePositionRequest request,
        ServerCallContext context)
    {
        var position = await _provider.GetOneByName(request.Position.Name, context.CancellationToken);

        if (position == null) throw new RpcException(new Status(StatusCode.NotFound, "Position not found"));

        return new GetOneByNamePositionResponse
        {
            Id = position.Id.ToString(),
            Name = position.Name,
            Description = position.Description
        };
    }
}
