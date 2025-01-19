using WC.Library.Domain.Models;

namespace WC.Service.Employees.Domain.Models;

public class PositionModel : ModelBase
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public List<EmployeeModel> Employees { get; set; } = [];
}
