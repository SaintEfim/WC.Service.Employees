using Microsoft.Extensions.Logging;
using WC.Service.Employees.Data.PostgreSql.Context;
using WC.Service.Employees.Data.Repositories;

namespace WC.Service.Employees.Data.PostgreSql.Repositories;

public class EmployeeRepository : EmployeeRepository<EmployeeDbContext>
{
    public EmployeeRepository(EmployeeDbContext context, ILogger<EmployeeRepository> logger) :
        base(
            context, logger)
    {
    }
}