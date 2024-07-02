using WC.Service.Employees.API.Models.Colleague;

namespace WC.Service.Employees.API.Models.Employee;

public class EmployeeCreateDto
{
    public string Name { get; set; } = string.Empty;
    
    public string Surname { get; set; } = string.Empty;
    
    public string? Patronymic { get; set; } = string.Empty;
    
    public string Email { get; set; } = string.Empty;
    
    public string Password { get; set; } = string.Empty;
    
    public string Position { get; set; } = string.Empty;
    
    public List<ColleagueCreateDto>? Colleagues { get; set; } = [];
}