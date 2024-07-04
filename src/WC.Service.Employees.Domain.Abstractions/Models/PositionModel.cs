using WC.Library.Domain.Models;

namespace WC.Service.Employees.Domain.Models;

public class PositionModel : ModelBase
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public List<EmployeeModel> Employees { get; set; } = [];
}