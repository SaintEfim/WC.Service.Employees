﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WC.Service.Employees.Domain;

namespace WC.Service.Employees.CreatePosition;

internal static class Program
{
    private static async Task Main()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddLogging(loggingBuilder => { loggingBuilder.AddConsole(); });

        serviceCollection.AddAutoMapper(typeof(AutoMapperProfile));

        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        var basePath = AppDomain.CurrentDomain.BaseDirectory;
        var projectPath = Path.Combine(basePath, "..", "..", "..");

        var configuration = new ConfigurationBuilder().SetBasePath(projectPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
            .Build();

        serviceCollection.AddSingleton<IConfiguration>(configuration);

        var builder = new ContainerBuilder();

        builder.Populate(serviceCollection);

        builder.RegisterModule<EmployeesDomainModule>();
        builder.RegisterType<CreatePosition>()
            .AsSelf();

        var container = builder.Build();

        await using var scope = container.BeginLifetimeScope();
        var createAdmin = scope.Resolve<CreatePosition>();
        await createAdmin.Create();
    }
}
