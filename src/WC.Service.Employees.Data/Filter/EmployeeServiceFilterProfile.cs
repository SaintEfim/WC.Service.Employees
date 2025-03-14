using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;
using WC.Service.Employees.Data.Models;

namespace WC.Service.Employees.Data.Filter;

public class EmployeeServiceFilterProfile : SieveProcessor
{
    public EmployeeServiceFilterProfile(
        IOptions<SieveOptions> options)
        : base(options)
    {
    }

    protected override SievePropertyMapper MapProperties(
        SievePropertyMapper mapper)
    {
        mapper.Property<EmployeeEntity>(p => p.Id)
            .CanFilter();

        mapper.Property<EmployeeEntity>(p => p.Name)
            .CanFilter()
            .CanSort();

        mapper.Property<EmployeeEntity>(p => p.Surname)
            .CanFilter()
            .CanSort();

        mapper.Property<EmployeeEntity>(p => p.Patronymic)
            .CanFilter()
            .CanSort();

        mapper.Property<EmployeeEntity>(p => p.PositionId)
            .CanFilter();

        mapper.Property<PositionEntity>(p => p.Id)
            .CanFilter();

        mapper.Property<PositionEntity>(p => p.Name)
            .CanFilter()
            .CanSort();

        mapper.Property<PositionEntity>(p => p.Description)
            .CanFilter()
            .CanSort();

        return mapper;
    }
}
