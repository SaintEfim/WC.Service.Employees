using Microsoft.Extensions.Logging;
using Sieve.Services;
using WC.Service.Employees.Data.PostgreSql.Context;
using WC.Service.Employees.Data.Repositories;

namespace WC.Service.Employees.Data.PostgreSql.Repositories;

public class ColleagueRepository : ColleagueRepository<EmployeeDbContext>
{
    public ColleagueRepository(
        EmployeeDbContext context,
        ILogger<ColleagueRepository> logger,
        ISieveProcessor sieveProcessor)
        : base(context, logger, sieveProcessor)
    {
    }
}
