using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WC.Library.Shared.Constants;
using WC.Service.Employees.Data.Models;

namespace WC.Service.Employees.Data.PostgreSql.Configuration;

public class PositionEntityConfiguration : IEntityTypeConfiguration<PositionEntity>
{
    public void Configure(
        EntityTypeBuilder<PositionEntity> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(CommonConstants.GenericNameMaxLength)
            .IsRequired();

        builder.HasIndex(p => p.Name)
            .IsUnique();
    }
}
