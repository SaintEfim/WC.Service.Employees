using System.ComponentModel.DataAnnotations;
using WC.Library.Web.Models;
using WC.Service.Employees.API.Models.Position;

namespace WC.Service.Employees.API.Models.Employee;

public class EmployeeDto : DtoBase
{
    [Required]
    public required string Name { get; set; }

    [Required]
    public required string Surname { get; set; }

    public string? Patronymic { get; set; }

    [Required]
    public required PositionDto Position { get; set; }
}
