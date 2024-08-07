using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using WC.Library.Domain.Services;
using WC.Library.Shared.Exceptions;
using WC.Service.Employees.Data.Models;
using WC.Service.Employees.Data.Repositories;
using WC.Service.Employees.Domain.Models;
using WC.Service.Employees.Domain.Services.Position;

namespace WC.Service.Employees.Domain.Services.Employee;

public class EmployeeManager
    : DataManagerBase<EmployeeManager, IEmployeeRepository, EmployeeModel, EmployeeEntity>,
        IEmployeeManager
{
    private readonly IPositionProvider _positionProvider;

    public EmployeeManager(
        IMapper mapper,
        ILogger<EmployeeManager> logger,
        IEmployeeRepository repository,
        IEnumerable<IValidator> validators,
        IPositionProvider positionProvider)
        : base(mapper, logger, repository, validators)
    {
        _positionProvider = positionProvider;
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

        model.PositionId = position.Id;
        model.Position = null!;

        return await base.CreateAction(model, cancellationToken);
    }
}
