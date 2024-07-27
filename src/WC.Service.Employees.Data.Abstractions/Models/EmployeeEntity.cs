using WC.Library.Data.Models;

namespace WC.Service.Employees.Data.Models;

public class EmployeeEntity : EntityBase
{
    public required string Name { get; set; }

    public required string Surname { get; set; }

    public string? Patronymic { get; set; }

    public required Guid PositionId { get; set; }

    public required PositionEntity Position { get; set; } = null!;

    public List<ColleagueEntity> Colleagues { get; set; } = [];
}
