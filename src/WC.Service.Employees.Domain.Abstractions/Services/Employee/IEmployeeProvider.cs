using WC.Library.Domain.Services;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.Domain.Services.Employee;

public interface IEmployeeProvider : IDataProvider<EmployeeModel>
{
    Task<EmployeeModel?> GetOneByEmail(
        string email,
        CancellationToken cancellationToken = default);

    Task<bool> DoesEmployeeWithEmailExist(
        string email,
        CancellationToken cancellationToken = default);
}
