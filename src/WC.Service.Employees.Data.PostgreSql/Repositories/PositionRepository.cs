using Microsoft.Extensions.Logging;
using Sieve.Services;
using WC.Service.Employees.Data.PostgreSql.Context;
using WC.Service.Employees.Data.Repositories;

namespace WC.Service.Employees.Data.PostgreSql.Repositories;

public class PositionRepository : PositionRepository<EmployeeDbContext>
{
    public PositionRepository(
        EmployeeDbContext context,
        ILogger<PositionRepository> logger,
        ISieveProcessor sieveProcessor)
        : base(context, logger, sieveProcessor)
    {
    }
}
