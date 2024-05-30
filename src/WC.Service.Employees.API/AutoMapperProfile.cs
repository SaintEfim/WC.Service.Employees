using AutoMapper;
using WC.Service.Employees.API.Models.Colleague;
using WC.Service.Employees.API.Models.Employee;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.API;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ColleagueDto, ColleagueModel>().ReverseMap();
        CreateMap<EmployeeDto, EmployeeModel>().ReverseMap();
    }
}