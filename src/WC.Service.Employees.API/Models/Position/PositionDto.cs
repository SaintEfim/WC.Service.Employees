using System.ComponentModel.DataAnnotations;
using WC.Library.Web.Models;

namespace WC.Service.Employees.API.Models.Position;

public class PositionDto : DtoBase
{
    [Required]
    public required string Name { get; set; }

    public string? Description { get; set; }
}
