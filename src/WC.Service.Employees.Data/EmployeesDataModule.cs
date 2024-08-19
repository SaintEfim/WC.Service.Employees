using Autofac;
using WC.Library.Data;

namespace WC.Service.Employees.Data;

public class EmployeesDataModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterModule<WcLibraryDataModule>();
    }
}
