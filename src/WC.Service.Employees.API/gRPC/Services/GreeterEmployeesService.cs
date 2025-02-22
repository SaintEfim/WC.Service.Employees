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

    public override async Task<SearchResponse> GetOneById(
        SearchRequest request,
        ServerCallContext context)
    {
        try
        {
            var searchResult =
                await _provider.GetOneById(Guid.Parse(request.Id), cancellationToken: context.CancellationToken);

            if (searchResult == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Not found employee with id: {request.Id}"));
            }

            return new SearchResponse
            {
                Id = searchResult.Id.ToString(),
                Name = searchResult.Name,
                Surname = searchResult.Surname,
                Patronymic = searchResult.Patronymic
            };
        }
        catch (Exception e)
        {
            throw new RpcException(new Status(StatusCode.Internal, $"{e.Message}"));
        }
    }
}
