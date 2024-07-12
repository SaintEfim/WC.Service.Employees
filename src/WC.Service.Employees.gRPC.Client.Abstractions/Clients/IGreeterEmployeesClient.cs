using WC.Library.Domain.Models;
using WC.Service.Employees.gRPC.Client.Models.Employee.Request;
using WC.Service.Employees.gRPC.Client.Models.Employee.Response;

namespace WC.Service.Employees.gRPC.Client.Clients;

public interface IGreeterEmployeesClient
{
    Task<ICollection<EmployeeListResponseModel>> Get(CancellationToken cancellationToken = default);

    Task<GetOneByEmailEmployeeResponseModel> GetOneByEmail(GetOneByEmailEmployeeRequestModel request,
        CancellationToken cancellationToken = default);

    Task<CreateResultModel> Create(EmployeeCreateRequestModel request, CancellationToken cancellationToken = default);

    Task<CreateResultModel> Update(EmployeeUpdateRequestModel request,
        CancellationToken cancellationToken = default);
}