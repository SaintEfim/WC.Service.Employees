using JetBrains.Annotations;

namespace WC.Service.Employees.gRPC.Client.Models.Employee.DoesEmployeeWithEmailExist;

public class DoesEmployeeWithEmailExistResponseModel
{
    public required bool Exists { [UsedImplicitly] get; set; }
}