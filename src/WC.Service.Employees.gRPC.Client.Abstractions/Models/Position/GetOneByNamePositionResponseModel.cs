namespace WC.Service.Employees.gRPC.Client.Models.Position;

public class GetOneByNamePositionResponseModel
{
    public required Guid Id { get; set; }

    public required string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}
