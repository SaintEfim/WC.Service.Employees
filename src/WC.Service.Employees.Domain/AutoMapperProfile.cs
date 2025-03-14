using AutoMapper;
using WC.Service.Employees.Data.Models;
using WC.Service.Employees.Domain.Models;
using WC.Service.Employees.Domain.Services.Employee;

namespace WC.Service.Employees.Domain;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<EmployeeModel, EmployeeEntity>()
            .ReverseMap();

        CreateMap<EmployeeCreatePayload, EmployeeModel>();

        CreateMap<PositionModel, PositionEntity>()
            .ReverseMap();
    }
}
