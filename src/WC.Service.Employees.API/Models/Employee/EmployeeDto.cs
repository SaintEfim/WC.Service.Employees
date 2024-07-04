using WC.Library.Web.Models;
using WC.Service.Employees.API.Models.Colleague;
using WC.Service.Employees.API.Models.Position;

namespace WC.Service.Employees.API.Models.Employee;

public class EmployeeDto : DtoBase
{
    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public string? Patronymic { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public Guid PositionId { get; set; }

    public PositionDto Position { get; set; } = null!;

    public string Role { get; set; } = "User";

    public List<ColleagueDto>? Colleagues { get; set; } = [];
}