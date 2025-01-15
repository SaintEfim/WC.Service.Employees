using FluentValidation;
using Grpc.Core;
using WC.Service.Employees.Domain.Services.Employee;

namespace WC.Service.Employees.API.gRPC.Services;

public class GreeterEmployeesService : GreeterEmployees.GreeterEmployeesBase
{
    private readonly IEmployeeManager _manager;

    public GreeterEmployeesService(
        IEmployeeManager manager)
    {
        _manager = manager;
    }

    public override async Task<EmployeeCreateResponse> Create(
        EmployeeCreateRequest request,
        ServerCallContext context)
    {
        try
        {
            var createItem = await _manager.Create(new EmployeeCreatePayload
            {
                Name = request.Name,
                Surname = request.Surname,
                Patronymic = request.Patronymic,
                Email = request.Email,
                Password = request.Password,
                PositionId = Guid.Parse(request.PositionId)
            }, cancellationToken: context.CancellationToken);

            return new EmployeeCreateResponse { EmployeeId = createItem.Id.ToString() };
        }
        catch (ValidationException e)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, $"{e.Message}"));
        }
        catch (Exception e)
        {
            throw new RpcException(new Status(StatusCode.Internal, $"{e.Message}"));
        }
    }
}
