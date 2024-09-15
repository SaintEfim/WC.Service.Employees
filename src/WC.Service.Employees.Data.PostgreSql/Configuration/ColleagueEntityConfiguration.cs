using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WC.Service.Employees.Data.Models;

namespace WC.Service.Employees.Data.PostgreSql.Configuration;

public class ColleagueEntityConfiguration : IEntityTypeConfiguration<ColleagueEntity>
{
    public void Configure(
        EntityTypeBuilder<ColleagueEntity> builder)
    {
        builder.HasOne(f => f.Employee)
            .WithMany(e => e.Colleagues)
            .HasForeignKey(f => f.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(f => f.ColleagueEmployee)
            .WithMany()
            .HasForeignKey(f => f.ColleagueEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
