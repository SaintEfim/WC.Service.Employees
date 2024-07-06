﻿using Grpc.Net.Client;
using WC.Library.Domain.Models;
using WC.Service.Employees.gRPC.Client.Models.Employee;
using WC.Service.Registration.gRPC.Client.Clients;

namespace WC.Service.Employees.gRPC.Client.Clients;

public class GreeterEmployeesClient : IGreeterEmployeesClient
{
    private readonly GreeterEmployees.GreeterEmployeesClient _client;

    public GreeterEmployeesClient(IEmployeesClientConfiguration configuration)
    {
        var channel = GrpcChannel.ForAddress(configuration.GetBaseUrl());
        _client = new GreeterEmployees.GreeterEmployeesClient(channel);
    }

    public async Task<CreateResultModel> Create(EmployeeCreateModel entity,
        CancellationToken cancellationToken)
    {
        var createResult =
            await _client.CreateAsync(new EmployeeCreateRequest
            {
                Employee = new Employee
                {
                    Name = entity.Name,
                    Surname = entity.Surname,
                    Patronymic = entity.Patronymic,
                    Email = entity.Email,
                    Password = entity.Password,
                    PositionId = entity.PositionId.ToString()
                }
            }, cancellationToken: cancellationToken);

        return new CreateResultModel
        {
            Id = Guid.Parse(createResult.Id)
        };
    }
}