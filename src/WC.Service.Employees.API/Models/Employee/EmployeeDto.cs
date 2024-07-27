using System.ComponentModel.DataAnnotations;
using WC.Library.Web.Models;

namespace WC.Service.Employees.API.Models.Employee;

public class EmployeeDto : DtoBase
{
    [Required]
    public required string Name { get; set; }

    [Required]
    public required string Surname { get; set; }

    public string? Patronymic { get; set; }

    [Required]
    public required Guid PositionId { get; set; }
}
