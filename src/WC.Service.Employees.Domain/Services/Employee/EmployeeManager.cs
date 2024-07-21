using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using WC.Library.Domain.Services;
using WC.Service.Employees.Data.Models;
using WC.Service.Employees.Data.Repositories;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.Domain.Services.Employee;

public class EmployeeManager
    : DataManagerBase<EmployeeManager, IEmployeeRepository, EmployeeModel, EmployeeEntity>,
        IEmployeeManager
{
    public EmployeeManager(
        IMapper mapper,
        ILogger<EmployeeManager> logger,
        IEmployeeRepository repository,
        IEnumerable<IValidator> validators)
        : base(mapper, logger, repository, validators)
    {
    }
}
