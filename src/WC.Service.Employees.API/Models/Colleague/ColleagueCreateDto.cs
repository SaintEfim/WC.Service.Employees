using System.ComponentModel.DataAnnotations;

namespace WC.Service.Employees.API.Models.Colleague;

public class ColleagueCreateDto
{
    [Required]
    public required Guid EmployeeId { get; set; }

    [Required]
    public required Guid ColleagueEmployeeId { get; set; }
}
