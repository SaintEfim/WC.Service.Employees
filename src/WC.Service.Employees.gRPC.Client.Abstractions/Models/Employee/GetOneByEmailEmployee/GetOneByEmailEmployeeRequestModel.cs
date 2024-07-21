namespace WC.Service.Employees.gRPC.Client.Models.Employee.GetOneByEmailEmployee;

public class GetOneByEmailEmployeeRequestModel
{
    public required string Email { get; set; } = string.Empty;
}
