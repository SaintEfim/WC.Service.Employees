using Autofac;
using WC.Service.Employees.gRPC.Client.Clients;

namespace WC.Service.Employees.gRPC.Client;

public class EmployeeClientModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterType<GreeterEmployeesClient>()
            .As<IGreeterEmployeesClient>()
            .InstancePerLifetimeScope();

        builder.RegisterType<GreeterPositionsClient>()
            .As<IGreeterPositionsClient>()
            .InstancePerLifetimeScope();
    }
}