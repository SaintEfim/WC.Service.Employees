namespace WC.Service.Employees.gRPC.Client.Models.Employee;

public class EmployeeCreateRequestModel
{
    public required string Name { get; set; }

    public required string Surname { get; set; }

    public string Patronymic { get; set; } = string.Empty;

    public required string Email { get; set; } = string.Empty;

    public required string Password { get; set; } = string.Empty;

    public required string PositionName { get; set; }
}
