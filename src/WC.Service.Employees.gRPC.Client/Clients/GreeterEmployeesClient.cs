using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using WC.Library.Domain.Models;
using WC.Service.Employees.gRPC.Client.Models.Employee.Request;
using WC.Service.Employees.gRPC.Client.Models.Employee.Response;

namespace WC.Service.Employees.gRPC.Client.Clients;

public class GreeterEmployeesClient : IGreeterEmployeesClient
{
    private readonly GreeterEmployees.GreeterEmployeesClient _client;

    public GreeterEmployeesClient(IEmployeesClientConfiguration configuration)
    {
        var channel = GrpcChannel.ForAddress(configuration.GetBaseUrl());
        _client = new GreeterEmployees.GreeterEmployeesClient(channel);
    }

    public async Task<ICollection<EmployeeListResponseModel>> Get(
        CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync(new Empty(), cancellationToken: cancellationToken);

        var employees = response.Employee.Select(e => new EmployeeListResponseModel
        {
            Id = Guid.Parse(e.Id),
            Name = e.Name,
            Surname = e.Surname,
            Patronymic = e.Patronymic,
            Email = e.Email,
            Password = e.Password,
            PositionId = Guid.Parse(e.PositionId),
            Role = e.Role
        }).ToList();

        return employees;
    }

    public async Task<GetOneByEmailEmployeeResponseModel> GetOneByEmail(
        GetOneByEmailEmployeeRequestModel request,
        CancellationToken cancellationToken)
    {
        var employee = await _client.GetOneByEmailAsync(new EmployeeGetByEmailRequest
        {
            Email = request.Email
        }, cancellationToken: cancellationToken);

        return new GetOneByEmailEmployeeResponseModel
        {
            Id = Guid.Parse(employee.Employee.Id),
            Name = employee.Employee.Name,
            Surname = employee.Employee.Surname,
            Patronymic = employee.Employee.Patronymic,
            Email = employee.Employee.Email,
            Password = employee.Employee.Password,
            PositionId = Guid.Parse(employee.Employee.PositionId),
            Role = employee.Employee.Role
        };
    }

    public async Task<CreateResultModel> Create(EmployeeCreateRequestModel request,
        CancellationToken cancellationToken)
    {
        var createResult =
            await _client.CreateAsync(new EmployeeCreateRequest
            {
                Employee = new Employee
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    Patronymic = request.Patronymic,
                    Email = request.Email,
                    Password = request.Password,
                    PositionId = request.PositionId.ToString()
                }
            }, cancellationToken: cancellationToken);

        return new CreateResultModel
        {
            Id = Guid.Parse(createResult.Id)
        };
    }

    public async Task<CreateResultModel> Update(EmployeeUpdateRequestModel request,
        CancellationToken cancellationToken)
    {
        var updateResult =
            await _client.UpdateAsync(new EmployeeUpdateRequest
            {
                Employee = new Employee
                {
                    Id = request.Id.ToString(),
                    Name = request.Name,
                    Surname = request.Surname,
                    Patronymic = request.Patronymic,
                    Email = request.Email,
                    Password = request.Password,
                    PositionId = request.PositionId.ToString(),
                    Role = request.Role
                }
            }, cancellationToken: cancellationToken);

        return new CreateResultModel
        {
            Id = Guid.Parse(updateResult.Id)
        };
    }
}