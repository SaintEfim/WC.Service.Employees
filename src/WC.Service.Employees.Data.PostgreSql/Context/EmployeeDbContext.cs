using Microsoft.EntityFrameworkCore;
using WC.Service.Employees.Data.Models;
using WC.Service.Employees.Data.PostgreSql.Configuration;

namespace WC.Service.Employees.Data.PostgreSql.Context;

public sealed class EmployeeDbContext : DbContext
{
    public EmployeeDbContext(
        DbContextOptions<EmployeeDbContext> options)
        : base(options)
    {
        Database.Migrate();
    }

    public DbSet<EmployeeEntity> Employees { get; set; } = null!;
    public DbSet<PositionEntity> Positions { get; set; } = null!;

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmployeeEntityConfiguration());
        modelBuilder.ApplyConfiguration(new PositionEntityConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
