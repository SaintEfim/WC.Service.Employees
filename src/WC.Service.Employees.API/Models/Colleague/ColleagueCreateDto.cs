using System.ComponentModel.DataAnnotations;

namespace WC.Service.Employees.API.Models.Colleague;

public class ColleagueCreateDto
{
    [Required] public Guid EmployeeId { get; set; }

    [Required] public Guid ColleagueEmployeeId { get; set; }
}