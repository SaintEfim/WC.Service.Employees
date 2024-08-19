namespace WC.Service.Employees.Domain.Services.Employee;

public class EmployeeCreatePayload
{
    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public string? Patronymic { get; set; }

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public Guid PositionId { get; set; }
}
