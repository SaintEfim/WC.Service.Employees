using JetBrains.Annotations;

namespace WC.Service.Employees.gRPC.Client.Models.Position;

public class GetOneByNamePositionResponseModel
{
    public required Guid Id { [UsedImplicitly] get; set; }

    public required string Name { [UsedImplicitly] get; set; } = string.Empty;

    public required string? Description { [UsedImplicitly] get; set; }
}