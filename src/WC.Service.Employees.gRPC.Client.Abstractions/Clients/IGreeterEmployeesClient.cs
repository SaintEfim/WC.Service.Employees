using WC.Service.Employees.gRPC.Client.Models.Employee;

namespace WC.Service.Employees.gRPC.Client.Clients;

public interface IGreeterEmployeesClient
{
    Task<EmployeeCreateResponseModel> Create(
        EmployeeCreateRequestModel request,
        CancellationToken cancellationToken = default);

    Task<SearchResponseModel> GetOneById(
        SearchRequestModel request,
        CancellationToken cancellationToken = default);
}
