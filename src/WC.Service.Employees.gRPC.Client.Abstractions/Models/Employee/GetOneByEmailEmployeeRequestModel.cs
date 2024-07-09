namespace WC.Service.Employees.gRPC.Client.Models.Employee;

public class GetOneByEmailEmployeeRequestModel
{
    public required string Email { get; set; } = string.Empty;
}