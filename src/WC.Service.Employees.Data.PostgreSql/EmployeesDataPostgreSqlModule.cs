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
        builder.RegisterModule<EmployeesDataModule>();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .AsClosedTypesOf(typeof(IRepository<>))
            .AsImplementedInterfaces();

        builder.RegisterType<EmployeeDbContextFactory>()
            .AsSelf()
            .SingleInstance();

        builder.Register(c => c.Resolve<EmployeeDbContextFactory>()
                .CreateDbContext())
            .As<EmployeeDbContext>()
            .As<DbContext>()
            .InstancePerLifetimeScope();
    }
}
