namespace WC.Service.Employees.gRPC.Client.Models.Employee;

public class EmployeeListResponseModel
{
    public required Guid Id { get; set; }

    public required string Name { get; set; }
    public required string Surname { get; set; }

    public string? Patronymic { get; set; }

    public required Guid PositionId { get; set; }

    public required string Role { get; set; }
}
