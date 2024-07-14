using JetBrains.Annotations;

namespace WC.Service.Employees.gRPC.Client.Models.Employee;

public class EmployeeListResponseModel
{
    public required Guid Id { [UsedImplicitly] get; set; }

    public required string Name { [UsedImplicitly] get; set; } = string.Empty;

    public required string Surname { [UsedImplicitly] get; set; } = string.Empty;

    public required string? Patronymic { [UsedImplicitly] get; set; } = string.Empty;

    public required string Email { [UsedImplicitly] get; set; } = string.Empty;

    public required string Password { [UsedImplicitly] get; set; } = string.Empty;

    public required Guid PositionId { [UsedImplicitly] get; set; }

    public required string Role { [UsedImplicitly] get; set; } = string.Empty;
}