using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sieve.Services;
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
        ILogger<EmployeeRepository<TDbContext>> logger,
        ISieveProcessor sieveProcessor)
        : base(context, logger, sieveProcessor)
    {
    }

    protected override IQueryable<EmployeeEntity> FillRelatedRecords(
        IQueryable<EmployeeEntity> query)
    {
        return query.Include(x => x.Position);
    }
}
