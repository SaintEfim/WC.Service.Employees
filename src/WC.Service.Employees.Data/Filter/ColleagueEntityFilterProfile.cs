using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;
using WC.Service.Employees.Data.Models;

namespace WC.Service.Employees.Data.Filter;

public class ColleagueEntityFilterProfile : SieveProcessor
{
    public ColleagueEntityFilterProfile(
        IOptions<SieveOptions> options)
        : base(options)
    {
    }

    protected override SievePropertyMapper MapProperties(
        SievePropertyMapper mapper)
    {
        mapper.Property<ColleagueEntity>(p => p.Id)
            .CanFilter();

        mapper.Property<ColleagueEntity>(p => p.EmployeeId)
            .CanFilter();

        mapper.Property<ColleagueEntity>(p => p.ColleagueEmployeeId)
            .CanFilter();

        return mapper;
    }
}
