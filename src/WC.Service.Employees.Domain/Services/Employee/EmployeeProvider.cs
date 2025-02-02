using AutoMapper;
using Microsoft.Extensions.Logging;
using WC.Library.Data.Services;
using WC.Library.Domain.Services;
using WC.Service.Employees.Data.Models;
using WC.Service.Employees.Data.Repositories;
using WC.Service.Employees.Domain.Models;
using WC.Service.PersonalData.gRPC.Client.Clients;
using WC.Service.PersonalData.gRPC.Client.Models.GetEmailEmployee;

namespace WC.Service.Employees.Domain.Services.Employee;

public class EmployeeProvider
    : DataProviderBase<EmployeeProvider, IEmployeeRepository, EmployeeModel, EmployeeEntity>,
        IEmployeeProvider
{
    private readonly IGreeterPersonalDataClient _personalDataClient;

    public EmployeeProvider(
        IMapper mapper,
        ILogger<EmployeeProvider> logger,
        IEmployeeRepository repository,
        IGreeterPersonalDataClient personalDataClient)
        : base(mapper, logger, repository)
    {
        _personalDataClient = personalDataClient;
    }

    public override async Task<EmployeeModel?> GetOneById(
        Guid id,
        bool withIncludes = false,
        IWcTransaction? transaction = null,
        CancellationToken cancellationToken = default)
    {
        var employee = await Repository.GetOneById(id, withIncludes, transaction, cancellationToken);

        var email = await _personalDataClient.GetEmailEmployee(
            new GetEmailEmployeeRequestModel
            {
                EmployeeId = employee!.Id,
            }, cancellationToken);

        var employeeDetail = Mapper.Map<EmployeeModel>(employee);

        employeeDetail.Email = email.Email!;

        return employeeDetail;
    }
}
