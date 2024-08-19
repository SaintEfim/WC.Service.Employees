using WC.Library.Domain.Models;

namespace WC.Service.Employees.Domain.Models;

public class EmployeeModel : ModelBase
{
    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public string? Patronymic { get; set; }

    public Guid PositionId { get; set; }

    public PositionModel Position { get; set; } = null!;

    public List<ColleagueModel> Colleagues { get; set; } = [];
}
