using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WC.Library.Data.Repository;
using WC.Service.Employees.Data.Models;

namespace WC.Service.Employees.Data.Repositories;

public class EmployeeRepository<TDbContext>
    : RepositoryBase<EmployeeRepository<TDbContext>, TDbContext, EmployeeEntity>,
        IEmployeeRepository
    where TDbContext : DbContext
{
    protected EmployeeRepository(
        TDbContext context,
        ILogger<EmployeeRepository<TDbContext>> logger)
        : base(context, logger)
    {
    }

    protected override IQueryable<EmployeeEntity> FillRelatedRecords(
        IQueryable<EmployeeEntity> query)
    {
        return query.Include(x => x.Position)
            .Include(x => x.Colleagues)
            .ThenInclude(x => x.ColleagueEmployee)
            .ThenInclude(x => x.Position);
    }
}
