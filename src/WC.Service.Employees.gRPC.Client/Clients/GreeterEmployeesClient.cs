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
        CancellationToken cancellationToken)
    {
        var createResult = await _client.CreateAsync(new EmployeeCreateRequest
        {
            Name = request.Name,
            Surname = request.Surname,
            Patronymic = request.Patronymic,
            Email = request.Email,
            Password = request.Password,
            PositionName = request.PositionName
        }, cancellationToken: cancellationToken);

        return new EmployeeCreateResponseModel { EmployeeId = Guid.Parse(createResult.EmployeeId) };
    }
}
