namespace WC.Service.Employees.gRPC.Client.Models.Employee;

public class SearchRequestModel
{
    public required List<Guid> Ids { get; set; }
}
