using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using WC.Library.Domain.Models;
using WC.Service.Employees.gRPC.Client.Models.Employee;
using WC.Service.Employees.gRPC.Client.Models.Employee.GetOneById;

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

    public async Task<ICollection<EmployeeListResponseModel>> Get(
        CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync(new Empty(), cancellationToken: cancellationToken);

        var employees = response.Employee
            .Select(e => new EmployeeListResponseModel
            {
                Id = Guid.Parse(e.Id),
                Name = e.Name,
                Surname = e.Surname,
                Patronymic = e.Patronymic,
                PositionId = Guid.Parse(e.PositionId),
                Role = e.Role
            })
            .ToList();

        return employees;
    }

    public async Task<EmployeeGetByIdResponseModel> GetOneById(
        EmployeeGetByIdRequestModel request,
        CancellationToken cancellationToken = default)
    {
        var response = await _client.GetOneByIdAsync(new EmployeeGetByIdRequest { Id = request.Id.ToString() },
            cancellationToken: cancellationToken);

        return new EmployeeGetByIdResponseModel
        {
            Id = Guid.Parse(response.Employee.Id),
            Name = response.Employee.Name,
            Surname = response.Employee.Surname,
            Patronymic = response.Employee.Patronymic,
            PositionId = Guid.Parse(response.Employee.PositionId),
            Role = response.Employee.Role
        };
    }

    public async Task<CreateResultModel> Create(
        EmployeeCreateRequestModel request,
        CancellationToken cancellationToken)
    {
        var createResult = await _client.CreateAsync(
            new EmployeeCreateRequest
            {
                Employee = new Employee
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    Patronymic = request.Patronymic,
                    PositionId = request.PositionId.ToString()
                }
            }, cancellationToken: cancellationToken);

        return new CreateResultModel { Id = Guid.Parse(createResult.Id) };
    }

    public async Task Update(
        EmployeeUpdateRequestModel request,
        CancellationToken cancellationToken)
    {
        await _client.UpdateAsync(new EmployeeUpdateRequest
        {
            Employee = new Employee
            {
                Id = request.Id.ToString(),
                Name = request.Name,
                Surname = request.Surname,
                Patronymic = request.Patronymic,
                PositionId = request.PositionId.ToString(),
                Role = request.Role
            }
        }, cancellationToken: cancellationToken);
    }

    public async Task Delete(
        EmployeeDeleteRequestModel request,
        CancellationToken cancellationToken)
    {
        await _client.DeleteAsync(new EmployeeDeleteRequest { Id = request.Id.ToString() },
            cancellationToken: cancellationToken);
    }
}
