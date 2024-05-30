using Microsoft.EntityFrameworkCore;
using WC.Service.Employees.Data.Models;

namespace WC.Service.Employees.Data.PostgreSql.Context;

public class EmployeeDbContext : DbContext
{
    public DbSet<EmployeeEntity> Employees { get; set; } = null!;
    public DbSet<ColleagueEntity> Colleagues { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ColleagueEntity>()
            .HasOne(f => f.Employee)
            .WithMany(e => e.Colleagues)
            .HasForeignKey(f => f.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ColleagueEntity>()
            .HasOne(f => f.ColleagueEmployee)
            .WithMany()
            .HasForeignKey(f => f.ColleagueEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}