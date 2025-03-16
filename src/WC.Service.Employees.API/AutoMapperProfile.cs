using AutoMapper;
using WC.Library.Web.Models;
using WC.Service.Employees.API.Models.Employee;
using WC.Service.Employees.API.Models.Position;
using WC.Service.Employees.Domain.Models;
using WC.Service.Employees.Domain.Services.Employee;

namespace WC.Service.Employees.API;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        MapEmployeeModels();
        MapPositionModels();
    }

    private void MapEmployeeModels()
    {
        CreateMap<EmployeeCreateDto, EmployeeCreatePayload>();

        CreateMap<EmployeeModel, CreateActionResultDto>();

        CreateMap<EmployeeModel, EmployeeDto>();

        CreateMap<EmployeeModel, EmployeeDetailDto>();
    }

    private void MapPositionModels()
    {
        CreateMap<PositionModel, PositionDto>();

        CreateMap<PositionCreateDto, PositionModel>();

        CreateMap<PositionModel, CreateActionResultDto>();
    }
}
