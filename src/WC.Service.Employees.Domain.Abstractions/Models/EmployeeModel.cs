using WC.Library.Domain.Models;

namespace WC.Service.Employees.Domain.Models;

public class EmployeeModel : ModelBase
{
    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public string Patronymic { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public Guid PositionId { get; set; }

    public PositionModel Position { get; set; } = null!;

    public List<ColleagueModel>? Colleagues { get; set; } = [];
}
