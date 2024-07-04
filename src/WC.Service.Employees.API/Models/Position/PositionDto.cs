using WC.Library.Web.Models;

namespace WC.Service.Employees.API.Models.Position;

public class PositionDto : DtoBase
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}