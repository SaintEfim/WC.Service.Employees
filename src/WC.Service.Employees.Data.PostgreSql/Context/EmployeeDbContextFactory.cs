using Microsoft.Extensions.Configuration;
using WC.Library.Data.PostgreSql.Context;

namespace WC.Service.Employees.Data.PostgreSql.Context;

public sealed class EmployeeDbContextFactory : PostgreSqlDbContextFactoryBase<EmployeeDbContext>
{
    public EmployeeDbContextFactory(
        IConfiguration configuration)
        : base(configuration)
    {
    }

    protected override string ConnectionString => "ServiceDB";
}
