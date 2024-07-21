using WC.Library.Data.Models;

namespace WC.Service.Employees.Data.Models;

public class EmployeeEntity : EntityBase
{
    public required string Name { get; set; } = string.Empty;

    public required string Surname { get; set; } = string.Empty;

    public string? Patronymic { get; set; } = string.Empty;

    public required string Email { get; set; } = string.Empty;

    public required string Password { get; set; } = string.Empty;

    public required Guid PositionId { get; set; }

    public required PositionEntity Position { get; set; } = null!;

    public required string Role { get; set; } = "User";

    public List<ColleagueEntity>? Colleagues { get; set; } = [];
}
