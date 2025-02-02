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

        builder.RegisterType<EmployeeServiceFilterProfile>()
            .As<ISieveProcessor>()
            .InstancePerLifetimeScope();
    }
}
