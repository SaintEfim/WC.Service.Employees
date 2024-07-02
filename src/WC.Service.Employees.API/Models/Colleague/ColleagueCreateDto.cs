namespace WC.Service.Employees.API.Models.Colleague;

public class ColleagueCreateDto
{
    public Guid EmployeeId { get; set; }
    
    public Guid ColleagueEmployeeId { get; set; }
}