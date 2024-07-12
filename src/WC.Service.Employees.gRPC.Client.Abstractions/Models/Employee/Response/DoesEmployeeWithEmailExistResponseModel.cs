namespace WC.Service.Employees.gRPC.Client.Models.Employee.Response;

public class DoesEmployeeWithEmailExistResponseModel
{
    public required bool Exists { get; set; }
}