using AutoMapper;
using Microsoft.Extensions.Logging;
using WC.Library.Domain.Services;
using WC.Service.Employees.Data.Models;
using WC.Service.Employees.Data.Repositories;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.Domain.Services.Employee;

public class EmployeeProvider : DataProviderBase<EmployeeProvider, IEmployeeRepository, EmployeeModel, EmployeeEntity>,
    IEmployeeProvider
{
    public EmployeeProvider(IMapper mapper, ILogger<EmployeeProvider> logger, IEmployeeRepository repository) : base(
        mapper, logger, repository)
    {
    }

    public async Task<EmployeeModel?> GetOneByEmail(string email, CancellationToken cancellationToken = default)
    {
        var employees = await Repository.Get(cancellationToken: cancellationToken);
        var employee = employees.SingleOrDefault(x => x.Email == email);

        return Mapper.Map<EmployeeModel>(employee);
    }

    public async Task<bool> DoesEmployeeWithEmailExist(string email, CancellationToken cancellationToken = default)
    {
        var employees = await Repository.Get(cancellationToken: cancellationToken);
        return employees.Any(x => x.Email == email);
    }
}