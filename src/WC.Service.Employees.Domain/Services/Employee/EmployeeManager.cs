using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
    private readonly IDistributedCache _cache;
    private readonly IGreeterPersonalDataClient _personalDataClient;
    private readonly IPositionProvider _positionProvider;

    public EmployeeManager(
        IMapper mapper,
        ILogger<EmployeeManager> logger,
        IEmployeeRepository repository,
        IEnumerable<IValidator> validators,
        IPositionProvider positionProvider,
        IGreeterPersonalDataClient personalDataClient,
        IDistributedCache cache)
        : base(mapper, logger, repository, validators)
    {
        _positionProvider = positionProvider;
        _personalDataClient = personalDataClient;
        _cache = cache;
    }

    protected override async Task<EmployeeModel> CreateAction(
        EmployeeModel model,
        CancellationToken cancellationToken = default)
    {
        var cachedEmployee = await GetCachedEmployee(model, cancellationToken);

        if (cachedEmployee != null)
        {
            return cachedEmployee;
        }

        if (model.PositionId == Guid.Empty)
        {
            await SetPositionId(model, cancellationToken);
        }

        var employee = await base.CreateAction(model, cancellationToken);
        model.Id = employee.Id;

        if (model.PositionId == Guid.Empty)
        {
            model.PositionId = employee.PositionId;
        }

        return await CreatePersonalDataAndCacheEmployee(model, cancellationToken);
    }

    private async Task SetPositionId(
        EmployeeModel model,
        CancellationToken cancellationToken)
    {
        if (model.Position == null)
        {
            throw new ArgumentException("Position is not provided and PositionId is empty");
        }

        var position = await _positionProvider.GetOneByName(model.Position.Name, cancellationToken);
        if (position == null)
        {
            throw new NotFoundException($"Position not found for name: {model.Position.Name}");
        }

        model.PositionId = position.Id;
        model.Position = null!;
    }

    private async Task<EmployeeModel?> GetCachedEmployee(
        EmployeeModel model,
        CancellationToken cancellationToken)
    {
        var modelCache = await _cache.GetStringAsync($"email-{model.Email}", cancellationToken);

        if (modelCache == null)
        {
            return null;
        }

        var cachedEmployee = JsonConvert.DeserializeObject<EmployeeModel>(modelCache);
        if (cachedEmployee == null)
        {
            await _cache.RemoveAsync(model.Email, cancellationToken);
            return null;
        }

        var existingEmployee = Mapper.Map<EmployeeModel>(await Repository.GetOneById(cachedEmployee.Id,
            cancellationToken: cancellationToken));

        if (existingEmployee == null)
        {
            await _cache.RemoveAsync(model.Email, cancellationToken);
            return null;
        }

        if (AreEmployeesEqual(model, existingEmployee))
        {
            return await CreatePersonalDataAndCacheEmployee(cachedEmployee, cancellationToken);
        }

        model.Id = existingEmployee.Id;
        await Repository.Update(Mapper.Map<EmployeeEntity>(model), cancellationToken);

        return await CreatePersonalDataAndCacheEmployee(cachedEmployee, cancellationToken);
    }

    private async Task<EmployeeModel> CreatePersonalDataAndCacheEmployee(
        EmployeeModel model,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await _personalDataClient.Create(new PersonalDataCreateRequestModel
            {
                EmployeeId = model.Id,
                Email = model.Email,
                Password = model.Password
            }, cancellationToken);

            await _cache.RemoveAsync(model.Email, cancellationToken);
            return model;
        }
        catch (Exception)
        {
            await CacheEmployee(model);
            throw;
        }
    }

    private async Task CacheEmployee(
        EmployeeModel model)
    {
        var employeeString = JsonConvert.SerializeObject(model);
        await _cache.SetStringAsync($"email-{model.Email}", employeeString,
            new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2) });
    }

    private static bool AreEmployeesEqual(
        EmployeeModel? a,
        EmployeeModel? b)
    {
        if (a == null || b == null)
        {
            return true;
        }

        return a.Name == b.Name && a.Surname == b.Surname && a.Patronymic == b.Patronymic &&
               a.PositionId == b.PositionId;
    }
}
