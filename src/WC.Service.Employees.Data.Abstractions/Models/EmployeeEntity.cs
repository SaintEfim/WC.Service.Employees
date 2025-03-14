using WC.Library.Data.Models;

namespace WC.Service.Employees.Data.Models;

public class EmployeeEntity : EntityBase
{
    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public string? Patronymic { get; set; }

    public Guid PositionId { get; set; }

    public PositionEntity Position { get; set; } = null!;
}
