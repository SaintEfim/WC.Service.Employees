using Microsoft.Extensions.Configuration;
using WC.Library.Data.PostgreSql.Context;

namespace WC.Service.Employees.Data.PostgreSql.Context;

public sealed class EmployeeDnContextFactory : PostgreSqlDbContextFactoryBase<EmployeeDbContext>
{
    protected override string ConnectionString => "ServiceDB";

    public EmployeeDnContextFactory(IConfiguration configuration) : base(configuration)
    {
    }
}