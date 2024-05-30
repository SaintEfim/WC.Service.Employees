using Microsoft.Extensions.Logging;
using WC.Service.Employees.Data.PostgreSql.Context;
using WC.Service.Employees.Data.Repositories;

namespace WC.Service.Employees.Data.PostgreSql.Repositories;

public class ColleagueRepository : ColleagueRepository<EmployeeDbContext>
{
    public ColleagueRepository(EmployeeDbContext context, ILogger<ColleagueRepository> logger) :
        base(
            context, logger)
    {
    }
}