using WC.Library.Domain.Models;
using WC.Service.Employees.gRPC.Client.Models.Employee;

namespace WC.Service.Employees.gRPC.Client.Clients;

public interface IGreeterEmployeesClient
{
    Task<CreateResultModel> Create(
        EmployeeCreateRequestModel request,
        CancellationToken cancellationToken = default);
}
