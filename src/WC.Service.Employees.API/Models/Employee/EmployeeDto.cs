﻿using System.ComponentModel.DataAnnotations;
using WC.Library.Web.Models;
using WC.Service.Employees.API.Models.Position;

namespace WC.Service.Employees.API.Models.Employee;

public class EmployeeDto : DtoBase
{
    [Required] public string Name { get; set; } = string.Empty;

    [Required] public string Surname { get; set; } = string.Empty;

    public string? Patronymic { get; set; } = string.Empty;

    [Required] public string Email { get; set; } = string.Empty;

    [Required] public string Password { get; set; } = string.Empty;

    [Required] public PositionDto Position { get; set; } = null!;
}