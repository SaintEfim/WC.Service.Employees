using AutoMapper;
using WC.Service.Employees.Data.Models;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.Domain;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ColleagueModel, ColleagueEntity>().ReverseMap();

        CreateMap<EmployeeModel, EmployeeEntity>()
            .ForMember(dest => dest.CreatedAt,
                opt => opt.MapFrom(src => DateTime.SpecifyKind(src.CreatedAt, DateTimeKind.Utc)))
            .ForMember(dest => dest.UpdatedAt,
                opt => opt.MapFrom(src =>
                    src.UpdatedAt.HasValue
                        ? (DateTime?)DateTime.SpecifyKind(src.UpdatedAt.Value, DateTimeKind.Utc)
                        : null));

        CreateMap<EmployeeEntity, EmployeeModel>();
    }
}