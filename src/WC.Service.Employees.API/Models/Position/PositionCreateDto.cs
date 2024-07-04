using System.ComponentModel.DataAnnotations;

namespace WC.Service.Employees.API.Models.Position;

public class PositionCreateDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public string? Description { get; set; }
}