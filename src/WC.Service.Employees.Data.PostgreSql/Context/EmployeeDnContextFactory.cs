using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using WC.Library.Data.PostgreSql.Context;

namespace WC.Service.Employees.Data.PostgreSql.Context;

public sealed class EmployeeDnContextFactory : PostgreSqlDbContextFactoryBase<EmployeeDbContext>
{
    public EmployeeDnContextFactory(IConfiguration configuration, IHostEnvironment environment) : base(configuration,
        environment)
    {
    }

    protected override string ConnectionString => "ServiceDB";
}