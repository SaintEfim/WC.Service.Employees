﻿using JetBrains.Annotations;

namespace WC.Service.Employees.gRPC.Client.Models.Employee;

public class EmployeeDeleteRequestModel
{
    public required Guid Id { get; [UsedImplicitly] set; }
}