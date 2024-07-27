using System.ComponentModel.DataAnnotations;
using WC.Library.Web.Models;
using WC.Service.Employees.API.Models.Colleague;
using WC.Service.Employees.API.Models.Position;

namespace WC.Service.Employees.API.Models.Employee;

public class EmployeeDetailDto : DtoBase
{
    [Required]
    public required string Name { get; set; } = string.Empty;

    [Required]
    public required string Surname { get; set; } = string.Empty;

    public string? Patronymic { get; set; }

    [Required]
    public required PositionDto Position { get; set; } = null!;

    public List<ColleagueDetailDto> Colleagues { get; set; } = [];
}
