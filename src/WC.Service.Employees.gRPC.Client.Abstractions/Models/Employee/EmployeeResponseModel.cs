namespace WC.Service.Employees.gRPC.Client.Models.Employee;

public class EmployeeResponseModel
{
    public required Guid Id { get; set; }

    public required string Name { get; set; }

    public required string Surname { get; set; }

    public string? Patronymic { get; set; }
}
