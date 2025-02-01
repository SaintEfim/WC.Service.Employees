using Autofac;
using Sieve.Services;
using WC.Library.Data;
using WC.Service.Employees.Data.Filter;

namespace WC.Service.Employees.Data;

public class EmployeesDataModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterModule<WcLibraryDataModule>();

        builder.RegisterType<ColleagueEntityFilterProfile>()
            .As<ISieveProcessor>()
            .InstancePerLifetimeScope();

        builder.RegisterType<EmployeeEntityFilterProfile>()
            .As<ISieveProcessor>()
            .InstancePerLifetimeScope();

        builder.RegisterType<PositionEntityFilterProfile>()
            .As<ISieveProcessor>()
            .InstancePerLifetimeScope();
    }
}
