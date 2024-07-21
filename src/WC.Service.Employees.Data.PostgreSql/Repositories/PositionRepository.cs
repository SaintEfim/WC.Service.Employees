using Microsoft.Extensions.Logging;
using WC.Service.Employees.Data.PostgreSql.Context;
using WC.Service.Employees.Data.Repositories;

namespace WC.Service.Employees.Data.PostgreSql.Repositories;

public class PositionRepository : PositionRepository<EmployeeDbContext>
{
    public PositionRepository(
        EmployeeDbContext context,
        ILogger<PositionRepository> logger)
        : base(context, logger)
    {
    }
}
