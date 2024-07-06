namespace WC.Service.Employees.gRPC.Client.Models.Position;

public class SearchPositionResponseModel
{
    public required Guid Id { get; set; }

    public required string Name { get; set; } = string.Empty;

    public required string? Description { get; set; }
}