using WC.Library.Domain.Models;
using WC.Service.Employees.gRPC.Client.Models.Employee;
using WC.Service.Employees.gRPC.Client.Models.Employee.GetOneById;

namespace WC.Service.Employees.gRPC.Client.Clients;

public interface IGreeterEmployeesClient
{
    Task<ICollection<EmployeeListResponseModel>> Get(
        CancellationToken cancellationToken = default);

    Task<EmployeeGetByIdResponseModel> GetOneById(
        EmployeeGetByIdRequestModel request,
        CancellationToken cancellationToken = default);

    Task<CreateResultModel> Create(
        EmployeeCreateRequestModel request,
        CancellationToken cancellationToken = default);

    Task Update(
        EmployeeUpdateRequestModel request,
        CancellationToken cancellationToken = default);

    Task Delete(
        EmployeeDeleteRequestModel request,
        CancellationToken cancellationToken = default);
}
