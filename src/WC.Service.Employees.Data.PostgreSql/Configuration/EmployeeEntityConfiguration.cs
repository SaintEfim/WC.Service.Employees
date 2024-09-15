using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WC.Library.Shared.Constants;
using WC.Service.Employees.Data.Models;

namespace WC.Service.Employees.Data.PostgreSql.Configuration;

public class EmployeeEntityConfiguration : IEntityTypeConfiguration<EmployeeEntity>
{
    public void Configure(
        EntityTypeBuilder<EmployeeEntity> builder)
    {
        builder.Property(e => e.Name)
            .HasMaxLength(CommonConstants.GenericNameMaxLength)
            .IsRequired();

        builder.Property(e => e.Surname)
            .HasMaxLength(CommonConstants.GenericNameMaxLength)
            .IsRequired();
    }
}
