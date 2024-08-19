using Autofac;
using WC.Service.Employees.API.gRPC.Services;
using WC.Service.Employees.Domain;
using StartupBase = WC.Library.Web.Startup.StartupBase;

namespace WC.Service.Employees.API;

internal sealed class Startup : StartupBase
{
    public Startup(
        WebApplicationBuilder builder)
        : base(builder)
    {
    }

    public override void ConfigureContainer(
        ContainerBuilder builder)
    {
        base.ConfigureContainer(builder);

        builder.RegisterModule<EmployeesDomainModule>();
    }

    public override void Configure(
        WebApplication app)
    {
        base.Configure(app);

        app.MapGrpcService<GreeterEmployeesService>();
    }
}
