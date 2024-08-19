using WC.Library.Data.Models;

namespace WC.Service.Employees.Data.Models;

public class ColleagueEntity : EntityBase
{
    public Guid EmployeeId { get; set; }

    public Guid ColleagueEmployeeId { get; set; }

    public EmployeeEntity Employee { get; set; } = null!;

    public EmployeeEntity ColleagueEmployee { get; set; } = null!;
}
