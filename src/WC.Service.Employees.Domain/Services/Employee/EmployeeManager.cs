﻿using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using WC.Library.Data.Services;
using WC.Library.Domain.Services;
using WC.Service.Employees.Data.Models;
using WC.Service.Employees.Data.Repositories;
using WC.Service.Employees.Domain.Models;
using WC.Service.PersonalData.gRPC.Client.Clients;
using WC.Service.PersonalData.gRPC.Client.Models;
using WC.Service.PersonalData.gRPC.Client.Models.Create;

namespace WC.Service.Employees.Domain.Services.Employee;

public class EmployeeManager
    : DataManagerBase<EmployeeManager, IEmployeeRepository, EmployeeModel, EmployeeEntity>,
        IEmployeeManager
{
    private readonly IGreeterPersonalDataClient _personalDataClient;
    private readonly IWcTransactionService _transactionService;

    public EmployeeManager(
        IMapper mapper,
        ILogger<EmployeeManager> logger,
        IEmployeeRepository repository,
        IWcTransactionService transactionService,
        IEnumerable<IValidator> validators,
        IGreeterPersonalDataClient personalDataClient)
        : base(mapper, logger, repository, validators)
    {
        _transactionService = transactionService;
        _personalDataClient = personalDataClient;
    }

    public Task<EmployeeModel> Create(
        EmployeeCreatePayload payload,
        IWcTransaction? transaction = default,
        CancellationToken cancellationToken = default)
    {
        return _transactionService.Execute(async (
            tr,
            token) =>
        {
            var employee = await Create(Mapper.Map<EmployeeModel>(payload), tr, token);

            await _personalDataClient.Create(new PersonalDataCreateRequestModel
            {
                EmployeeId = employee.Id,
                Email = payload.Email,
                Password = payload.Password
            }, cancellationToken);

            return employee;
        }, transaction, cancellationToken);
    }

    protected override Task<EmployeeModel> DeleteAction(
        Guid id,
        IWcTransaction? transaction = default,
        CancellationToken cancellationToken = default)
    {
        return _transactionService.Execute(async (
            tr,
            token) =>
        {
            var employee = await Repository.Delete(id, tr, token);

            await _personalDataClient.Delete(new PersonalDataDeleteRequestModel
            {
                Id = id
            }, token);

            return Mapper.Map<EmployeeModel>(employee);
        }, transaction, cancellationToken);
    }
}
