using WC.Library.Data.Models;

namespace WC.Service.Employees.Data.Models;

public class PositionEntity : EntityBase
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public List<EmployeeEntity> Employees { get; set; } = [];
}
