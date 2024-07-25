using WC.Library.Domain.Models;

namespace WC.Service.Employees.Domain.Models;

public class EmployeeModel : ModelBase
{
    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public string? Patronymic { get; set; } = string.Empty;

    public Guid PositionId { get; set; }

    public virtual PositionModel Position { get; set; } = null!;

    public string Role { get; set; } = "User";

    public List<ColleagueModel>? Colleagues { get; set; } = [];
}
