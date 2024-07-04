using WC.Library.Domain.Models;

namespace WC.Service.Employees.Domain.Models;

public class ColleagueModel : ModelBase
{
    public Guid EmployeeId { get; set; }
    
    public Guid ColleagueEmployeeId { get; set; }

    public EmployeeModel Employee { get; set; } = null!;
    
    public EmployeeModel ColleagueEmployee { get; set; } = null!;
}