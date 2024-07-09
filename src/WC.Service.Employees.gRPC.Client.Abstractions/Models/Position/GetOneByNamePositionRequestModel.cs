namespace WC.Service.Employees.gRPC.Client.Models.Position;

public class GetOneByNamePositionRequestModel
{
    public required string Name { get; set; } = string.Empty;
}