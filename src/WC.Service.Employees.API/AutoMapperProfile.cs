using AutoMapper;
using WC.Library.Web.Models;
using WC.Service.Employees.API.Models.Colleague;
using WC.Service.Employees.API.Models.Employee;
using WC.Service.Employees.API.Models.Position;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.API;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ColleagueModel, ColleagueDto>();

        CreateMap<ColleagueModel, ColleagueDetailDto>();

        CreateMap<ColleagueCreateDto, ColleagueModel>();

        CreateMap<ColleagueModel, CreateActionResultDto>();

        CreateMap<EmployeeModel, EmployeeDto>();

        CreateMap<EmployeeModel, EmployeeDetailDto>();

        CreateMap<PositionModel, PositionDto>();

        CreateMap<PositionCreateDto, PositionModel>();

        CreateMap<PositionModel, CreateActionResultDto>();
    }
}
