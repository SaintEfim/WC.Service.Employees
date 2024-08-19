using WC.Library.Data.Services;
using WC.Library.Domain.Services;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.Domain.Services.Employee;

public interface IEmployeeManager : IDataManager<EmployeeModel>
{
    Task<EmployeeModel> Create(
        EmployeeCreatePayload payload,
        IWcTransaction? transaction = default,
        CancellationToken cancellationToken = default);
}
