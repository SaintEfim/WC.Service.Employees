using Autofac;
using Microsoft.EntityFrameworkCore;
using WC.Library.Data.Repository;
using WC.Service.Employees.Data.PostgreSql.Context;

namespace WC.Service.Employees.Data.PostgreSql;

public class EmployeesDataPostgreSqlModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(ThisAssembly)
            .AsClosedTypesOf(typeof(IRepository<>))
            .AsImplementedInterfaces();

        builder.RegisterType<EmployeeDnContextFactory>()
            .AsSelf()
            .SingleInstance();

        builder.Register(c => c.Resolve<EmployeeDnContextFactory>().CreateDbContext())
            .As<EmployeeDbContext>()
            .As<DbContext>()
            .InstancePerLifetimeScope();
    }
}