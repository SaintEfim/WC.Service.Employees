using WC.Library.Web.Models;
using WC.Service.Employees.API.Models.Employee;

namespace WC.Service.Employees.API.Models.Colleague;

public class ColleagueDto : DtoBase
{
    public Guid EmployeeId { get; set; }
    public Guid ColleagueEmployeeId { get; set; }

    public EmployeeDto Employee { get; set; } = null!;
    public EmployeeDto ColleagueEmployee { get; set; } = null!;
}