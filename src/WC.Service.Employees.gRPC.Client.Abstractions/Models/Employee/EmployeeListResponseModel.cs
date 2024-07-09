namespace WC.Service.Employees.gRPC.Client.Models.Employee;

public class EmployeeListResponseModel
{
    public required Guid Id { get; set; }

    public required string Name { get; set; } = string.Empty;

    public required string Surname { get; set; } = string.Empty;

    public required string? Patronymic { get; set; } = string.Empty;

    public required string Email { get; set; } = string.Empty;

    public required string Password { get; set; } = string.Empty;

    public required Guid PositionId { get; set; }

    public required string Role { get; set; } = string.Empty;
}