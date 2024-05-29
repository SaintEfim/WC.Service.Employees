﻿using WC.Library.Data.Models;

namespace WC.Service.Employees.Data.Models;

public class EmployeeEntity : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string? Patronymic { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string Role { get; set; } = "User";

    public List<ColleagueEntity> Colleagues { get; set; } = new();

    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
}