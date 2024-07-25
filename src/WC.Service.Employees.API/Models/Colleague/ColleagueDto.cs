using System.ComponentModel.DataAnnotations;
using WC.Library.Web.Models;

namespace WC.Service.Employees.API.Models.Colleague;

public class ColleagueDto : DtoBase
{
    [Required]
    public required Guid EmployeeId { get; set; }

    [Required]
    public required Guid ColleagueEmployeeId { get; set; }
}
