namespace WC.Service.Employees.gRPC.Client.Models.Employee;

public class SearchResponseModel
{
    public required List<EmployeeResponseModel> Employees { get; set; }
}
