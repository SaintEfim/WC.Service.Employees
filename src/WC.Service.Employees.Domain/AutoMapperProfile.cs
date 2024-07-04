using AutoMapper;
using WC.Service.Employees.Data.Models;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.Domain;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ColleagueModel, ColleagueEntity>().ReverseMap();

        CreateMap<EmployeeModel, EmployeeEntity>().ReverseMap();

        CreateMap<PositionModel, PositionEntity>().ReverseMap();
    }
}