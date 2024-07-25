namespace WC.Service.Employees.gRPC.Client.Models.Employee;

public class EmployeeCreateRequestModel
{
    public required string Name { get; set; }

    public required string Surname { get; set; }

    public string? Patronymic { get; set; }

    public required Guid PositionId { get; set; }
}
