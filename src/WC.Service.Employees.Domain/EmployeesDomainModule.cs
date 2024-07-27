using Autofac;
using FluentValidation;
using WC.Library.Domain.Services;
using WC.Service.Employees.Data.PostgreSql;
using WC.Service.PersonalData.gRPC.Client;

namespace WC.Service.Employees.Domain;

public class EmployeesDomainModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterModule<EmployeesDataPostgreSqlModule>();
        builder.RegisterModule<PersonalDataClientModule>();

        builder.RegisterType<PersonalDataClientConfiguration>()
            .As<IPersonalDataClientConfiguration>()
            .InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .AsClosedTypesOf(typeof(IDataProvider<>))
            .AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .AsClosedTypesOf(typeof(IDataManager<>))
            .AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .AsClosedTypesOf(typeof(IValidator<>))
            .AsImplementedInterfaces();
    }
}
