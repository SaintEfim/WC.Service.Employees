using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using WC.Library.Domain.Services;
using WC.Library.Shared.Exceptions;
using WC.Service.Employees.Data.Models;
using WC.Service.Employees.Data.Repositories;
using WC.Service.Employees.Domain.Models;
using WC.Service.Employees.Domain.Services.Position;
using WC.Service.PersonalData.gRPC.Client.Clients;
using WC.Service.PersonalData.gRPC.Client.Models.Create;

namespace WC.Service.Employees.Domain.Services.Employee;

public class EmployeeManager
    : DataManagerBase<EmployeeManager, IEmployeeRepository, EmployeeModel, EmployeeEntity>,
        IEmployeeManager
{
    private readonly IGreeterPersonalDataClient _personalDataClient;
    private readonly IPositionProvider _positionProvider;

    public EmployeeManager(
        IMapper mapper,
        ILogger<EmployeeManager> logger,
        IEmployeeRepository repository,
        IEnumerable<IValidator> validators,
        IPositionProvider positionProvider,
        IGreeterPersonalDataClient personalDataClient)
        : base(mapper, logger, repository, validators)
    {
        _positionProvider = positionProvider;
        _personalDataClient = personalDataClient;
    }

    protected override async Task<EmployeeModel> CreateAction(
        EmployeeModel model,
        CancellationToken cancellationToken = default)
    {
        var position = await _positionProvider.GetOneByName(model.Position.Name, cancellationToken);

        if (position == null)
        {
            throw new NotFoundException($"Position with name '{model.Position.Name}' not found");
        }

        model.Position.Id = position.Id;
        model.Position.Description = position.Description;

        var employee = await base.CreateAction(model, cancellationToken);

        await _personalDataClient.Create(new PersonalDataCreateRequestModel
        {
            EmployeeId = employee.Id,
            Email = model.Email,
            Password = model.Password
        }, cancellationToken);

        return employee;
    }
}
