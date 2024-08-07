using Grpc.Core;
using WC.Service.Employees.Domain.Models;
using WC.Service.Employees.Domain.Services.Employee;
using WC.Service.PersonalData.gRPC.Client.Clients;
using WC.Service.PersonalData.gRPC.Client.Models.Create;

namespace WC.Service.Employees.API.gRPC.Services;

public class GreeterEmployeesService : GreeterEmployees.GreeterEmployeesBase
{
    private readonly IEmployeeManager _manager;
    private readonly IGreeterPersonalDataClient _personalDataClient;

    public GreeterEmployeesService(
        IEmployeeManager manager,
        IGreeterPersonalDataClient personalDataClient)
    {
        _manager = manager;
        _personalDataClient = personalDataClient;
    }

    public override async Task<EmployeeCreateResponse> Create(
        EmployeeCreateRequest request,
        ServerCallContext context)
    {
        var createItem = await _manager.Create(new EmployeeModel
        {
            Name = request.Name,
            Surname = request.Surname,
            Patronymic = request.Patronymic,
            Position = new PositionModel { Name = request.PositionName }
        }, context.CancellationToken);

        await _personalDataClient.Create(new PersonalDataCreateRequestModel
        {
            EmployeeId = createItem.Id,
            Email = request.Email,
            Password = request.Password
        }, context.CancellationToken);

        return new EmployeeCreateResponse { EmployeeId = createItem.Id.ToString() };
    }
}
