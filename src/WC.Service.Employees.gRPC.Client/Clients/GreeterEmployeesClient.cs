using Grpc.Net.Client;
using WC.Service.Employees.gRPC.Client.Models.Employee;

namespace WC.Service.Employees.gRPC.Client.Clients;

public class GreeterEmployeesClient : IGreeterEmployeesClient
{
    private readonly GreeterEmployees.GreeterEmployeesClient _client;

    public GreeterEmployeesClient(
        IEmployeesClientConfiguration configuration)
    {
        var channel = GrpcChannel.ForAddress(configuration.GetBaseUrl());
        _client = new GreeterEmployees.GreeterEmployeesClient(channel);
    }

    public async Task<EmployeeCreateResponseModel> Create(
        EmployeeCreateRequestModel request,
        CancellationToken cancellationToken = default)
    {
        var createResult = await _client.CreateAsync(new EmployeeCreateRequest
        {
            Name = request.Name,
            Surname = request.Surname,
            Patronymic = request.Patronymic,
            Email = request.Email,
            Password = request.Password,
            PositionId = request.PositionId.ToString()
        }, cancellationToken: cancellationToken);

        return new EmployeeCreateResponseModel { Id = Guid.Parse(createResult.Id) };
    }

    public async Task<SearchResponseModel> GetOneById(
        SearchRequestModel request,
        CancellationToken cancellationToken = default)
    {
        var searchResult = await _client.GetOneByIdAsync(new SearchRequest { Id = request.Id.ToString() },
            cancellationToken: cancellationToken);

        return new SearchResponseModel
        {
            Id = Guid.Parse(searchResult.Id),
            Name = searchResult.Name,
            Surname = searchResult.Surname,
            Patronymic = searchResult.Patronymic,
        };
    }
}
