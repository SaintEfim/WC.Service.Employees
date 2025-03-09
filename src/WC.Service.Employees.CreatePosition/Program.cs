using Autofac;
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
        builder.Register(context =>
            {
                var configuration = context.Resolve<IConfiguration>();
                var adminSection = configuration.GetSection("AdminSettings");

                var positionNames = adminSection.GetSection("PositionNames")
                    .GetChildren()
                    .Select(x => x.Value)
                    .ToArray();

                var adminPositionId = adminSection.GetValue<string>("AdminPositionId");

                return new AdminSettingsOptions
                {
                    PositionNames = positionNames!,
                    AdminPositionId = Guid.Parse(adminPositionId!)
                };
            })
            .As<AdminSettingsOptions>()
            .SingleInstance();

        var container = builder.Build();

        await using var scope = container.BeginLifetimeScope();
        var createAdmin = scope.Resolve<CreatePosition>();
        await createAdmin.Create();
    }
}
