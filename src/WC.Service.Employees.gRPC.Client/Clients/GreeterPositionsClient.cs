using Grpc.Net.Client;
using WC.Service.Employees.gRPC.Client.Models.Position;

namespace WC.Service.Employees.gRPC.Client.Clients;

public class GreeterPositionsClient : IGreeterPositionsClient
{
    private readonly GreeterPositions.GreeterPositionsClient _client;

    public GreeterPositionsClient(IEmployeesClientConfiguration configuration)
    {
        var channel = GrpcChannel.ForAddress(configuration.GetBaseUrl());
        _client = new GreeterPositions.GreeterPositionsClient(channel);
    }

    public async Task<GetOneByNamePositionResponseModel> GetOneByName(GetOneByNamePositionRequestModel request,
        CancellationToken cancellationToken)
    {
        var searchResult =
            await _client.GetOneByNamePositionAsync(new SearchPositionRequest
            {
                Position = new Position
                {
                    Name = request.Name
                }
            }, cancellationToken: cancellationToken);

        return new GetOneByNamePositionResponseModel
        {
            Id = Guid.Parse(searchResult.Id),
            Name = null!,
            Description = null
        };
    }
}