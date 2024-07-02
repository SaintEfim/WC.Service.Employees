using AutoMapper;
using WC.Library.Web.Models;
using WC.Service.Employees.API.Models.Colleague;
using WC.Service.Employees.API.Models.Employee;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.API;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ColleagueModel, ColleagueDto>();

        CreateMap<ColleagueCreateDto, ColleagueModel>();

        CreateMap<ColleagueModel, CreateActionResultDto>();

        CreateMap<EmployeeModel, EmployeeDto>();

        CreateMap<EmployeeCreateDto, EmployeeModel>();

        CreateMap<EmployeeModel, CreateActionResultDto>();
    }
}