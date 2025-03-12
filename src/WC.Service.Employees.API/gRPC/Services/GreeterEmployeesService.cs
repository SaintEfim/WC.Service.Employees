using FluentValidation;
using Grpc.Core;
using WC.Service.Employees.Domain.Services.Employee;

namespace WC.Service.Employees.API.gRPC.Services;

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

    public override async Task<EmployeeCreateResponse> Create(
        EmployeeCreateRequest request,
        ServerCallContext context)
    {
        try
        {
            var createResult = await _manager.Create(new EmployeeCreatePayload
            {
                Name = request.Name,
                Surname = request.Surname,
                Patronymic = request.Patronymic,
                Email = request.Email,
                Password = request.Password,
                PositionId = Guid.Parse(request.PositionId)
            }, cancellationToken: context.CancellationToken);

            return new EmployeeCreateResponse { Id = createResult.Id.ToString() };
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

    public override async Task<SearchResponse> Search(
        SearchRequest request,
        ServerCallContext context)
    {
        try
        {
            var ids = request.Ids
                .Select(Guid.Parse)
                .ToList();

            var employees = await _provider.Search(ids, cancellationToken: context.CancellationToken);

            var response = new SearchResponse();
            response.Employees.AddRange(employees.Select(e => new Employee
            {
                Id = e.Id.ToString(),
                Name = e.Name,
                Surname = e.Surname,
                Patronymic = e.Patronymic
            }));

            return response;
        }
        catch (RpcException)
        {
            throw;
        }
        catch (Exception e)
        {
            throw new RpcException(new Status(StatusCode.Internal, e.Message));
        }
    }
}
