using WC.Library.Data.Models;

namespace WC.Service.Employees.Data.Models;

public class ColleagueEntity : EntityBase
{
    public required Guid EmployeeId { get; set; }

    public required Guid ColleagueEmployeeId { get; set; }

    public required EmployeeEntity Employee { get; set; } = null!;

    public required EmployeeEntity ColleagueEmployee { get; set; } = null!;
}