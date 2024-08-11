using System.ComponentModel.DataAnnotations;
using WC.Library.Web.Models;
using WC.Service.Employees.API.Models.Employee;

namespace WC.Service.Employees.API.Models.Colleague;

public class ColleagueDetailDto : DtoBase
{
    [Required]
    public required EmployeeDetailDto ColleagueEmployee { get; set; }
}
