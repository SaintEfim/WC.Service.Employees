﻿using WC.Library.Domain.Models;

namespace WC.Service.Employees.Domain.Models;

public class EmployeeModel : ModelBase
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string? Patronymic { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string Role { get; set; } = "User";

    public List<ColleagueModel>? Colleagues { get; set; } = [];

    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
}