using System.ComponentModel.DataAnnotations;

namespace WC.Service.Employees.API.Models.Position;

public class PositionCreateDto
{
    [Required]
    public required string Name { get; set; }

    public string? Description { get; set; }
}
