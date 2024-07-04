using WC.Library.Data.Models;

namespace WC.Service.Employees.Data.Models;

public class EmployeeEntity : EntityBase
{
    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public string? Patronymic { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public Guid PositionId { get; set; }

    public virtual PositionEntity Position { get; set; } = null!;

    public string Role { get; set; } = "User";

    public List<ColleagueEntity>? Colleagues { get; set; } = [];
}