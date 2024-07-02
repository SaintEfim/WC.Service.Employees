﻿using Autofac;
using WC.Library.Web.Startup;
using WC.Service.Employees.Domain;
using WC.Service.Employees.gRPC.Services;

namespace WC.Service.Employees.gRPC;

internal sealed class Startup : StartupGrpcBase
{
    public Startup(WebApplicationBuilder builder) : base(builder)
    {
    }

    public override void ConfigureContainer(ContainerBuilder builder)
    {
        base.ConfigureContainer(builder);

        builder.RegisterModule<EmployeesDomainModule>();
    }

    public override void Configure(WebApplication app)
    {
        base.Configure(app);
        app.MapGrpcService<GreeterEmployeesService>();
    }
}