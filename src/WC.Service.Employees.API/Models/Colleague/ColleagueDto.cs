using System.ComponentModel.DataAnnotations;
using WC.Library.Web.Models;

namespace WC.Service.Employees.API.Models.Colleague;

public class ColleagueDto : DtoBase
{
    [Required] public Guid EmployeeId { get; set; }

    [Required] public Guid ColleagueEmployeeId { get; set; }
}