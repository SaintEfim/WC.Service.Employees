using WC.Library.Data.Services;
using WC.Library.Domain.Services;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.Domain.Services.Employee;

public interface IEmployeeProvider : IDataProvider<EmployeeModel>
{
    Task<List<EmployeeModel>> Search(
        List<Guid> ids,
        IWcTransaction? transaction = default,
        CancellationToken cancellationToken = default);
}
