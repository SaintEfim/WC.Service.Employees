using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using WC.Service.Employees.Domain.Models;
using WC.Service.Employees.Domain.Services.Employee;

namespace WC.Service.Employees.gRPC.Server.Services;

public class GreeterEmployeesService : GreeterEmployees.GreeterEmployeesBase
{
    private readonly IEmployeeManager _manager;
    private readonly IEmployeeProvider _provider;

    public GreeterEmployeesService(
        IEmployeeManager manager,
        IEmployeeProvider provider)
    {
        _manager = manager;
        _provider = provider;
    }

    public override async Task<EmployeeListResponse> Get(
        Empty request,
        ServerCallContext context)
    {
        var employees = await _provider.Get();

        var employeeList = new EmployeeListResponse();
        employeeList.Employee.AddRange(employees.Select(e => new Employee
        {
            Id = e.Id.ToString(),
            Name = e.Name,
            Surname = e.Surname,
            Patronymic = e.Patronymic,
            Email = e.Email,
            Password = e.Password,
            PositionId = e.PositionId.ToString()
        }));

        return employeeList;
    }

    public override async Task<EmployeeGetByEmailResponse> GetOneByEmail(
        EmployeeGetByEmailRequest request,
        ServerCallContext context)
    {
        var employee = await _provider.GetOneByEmail(request.Email, context.CancellationToken);
        if (employee == null) throw new RpcException(new Status(StatusCode.NotFound, "Employee not found"));

        var response = new EmployeeGetByEmailResponse
        {
            Employee = new Employee
            {
                Id = employee.Id.ToString(),
                Name = employee.Name,
                Surname = employee.Surname,
                Patronymic = employee.Patronymic,
                Email = employee.Email,
                Password = employee.Password,
                PositionId = employee.PositionId.ToString(),
                Role = employee.Role
            }
        };

        return response;
    }

    public override async Task<DoesEmployeeWithEmailExistResponse> DoesEmployeeWithEmailExist(
        DoesEmployeeWithEmailExistRequest request,
        ServerCallContext context)
    {
        var exists = await _provider.DoesEmployeeWithEmailExist(request.Email, context.CancellationToken);

        return new DoesEmployeeWithEmailExistResponse { Exists = exists };
    }

    public override async Task<EmployeeCreateResponse> Create(
        EmployeeCreateRequest request,
        ServerCallContext context)
    {
        var createItem = await _manager.Create(new EmployeeModel
        {
            Name = request.Employee.Name,
            Surname = request.Employee.Surname,
            Patronymic = request.Employee.Patronymic,
            Email = request.Employee.Email,
            Password = request.Employee.Password,
            PositionId = Guid.Parse(request.Employee.PositionId)
        }, context.CancellationToken);

        return new EmployeeCreateResponse { Id = createItem.Id.ToString() };
    }

    public override async Task<Empty> Update(
        EmployeeUpdateRequest request,
        ServerCallContext context)
    {
        await _manager.Update(new EmployeeModel
        {
            Id = Guid.Parse(request.Employee.Id),
            Name = request.Employee.Name,
            Surname = request.Employee.Surname,
            Patronymic = request.Employee.Patronymic,
            Email = request.Employee.Email,
            Password = request.Employee.Password,
            PositionId = Guid.Parse(request.Employee.PositionId)
        }, context.CancellationToken);

        return new Empty();
    }

    public override async Task<Empty> Delete(
        EmployeeDeleteRequest request,
        ServerCallContext context)
    {
        await _manager.Delete(Guid.Parse(request.Id), context.CancellationToken);

        return new Empty();
    }
}
