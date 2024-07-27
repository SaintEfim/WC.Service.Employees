using WC.Library.Data.Models;

namespace WC.Service.Employees.Data.Models;

public class PositionEntity : EntityBase
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public required List<EmployeeEntity> Employees { get; set; } = [];
}
