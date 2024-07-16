using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WC.Library.Data.Repository;
using WC.Service.Employees.Data.Models;

namespace WC.Service.Employees.Data.Repositories;

public class ColleagueRepository<TDbContext> :
    RepositoryBase<ColleagueRepository<TDbContext>, TDbContext, ColleagueEntity>,
    IColleagueRepository
    where TDbContext : DbContext
{
    protected ColleagueRepository(TDbContext context, ILogger<ColleagueRepository<TDbContext>> logger) : base(context,
        logger)
    {
    }

    protected override IQueryable<ColleagueEntity> FillRelatedRecords(
        IQueryable<ColleagueEntity> query)
    {
        return query.Include(x => x.ColleagueEmployee);
    }
}