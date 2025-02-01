using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sieve.Services;
using WC.Library.Data.Repository;
using WC.Service.Employees.Data.Models;

namespace WC.Service.Employees.Data.Repositories;

public class PositionRepository<TDbContext>
    : RepositoryBase<PositionRepository<TDbContext>, TDbContext, PositionEntity>,
        IPositionRepository
    where TDbContext : DbContext
{
    protected PositionRepository(
        TDbContext context,
        ILogger<PositionRepository<TDbContext>> logger,
        ISieveProcessor sieveProcessor)
        : base(context, logger, sieveProcessor)
    {
    }
}
