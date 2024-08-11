using System.ComponentModel.DataAnnotations;

namespace WC.Service.Employees.API.Models.Employee;

public class EmployeeCreateDto
{
    [Required]
    public required string Name { get; set; }

    [Required]
    public required string Surname { get; set; }

    public string? Patronymic { get; set; }

    [Required]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }

    [Required]
    public required Guid PositionId { get; set; }
}
