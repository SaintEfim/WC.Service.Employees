using AutoMapper;
using Microsoft.Extensions.Logging;
using WC.Library.Domain.Services;
using WC.Service.Employees.Data.Models;
using WC.Service.Employees.Data.Repositories;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.Domain.Services.Colleague;

public class ColleagueProvider
    : DataProviderBase<ColleagueProvider, IColleagueRepository, ColleagueModel, ColleagueEntity>,
        IColleagueProvider
{
    public ColleagueProvider(
        IMapper mapper,
        ILogger<ColleagueProvider> logger,
        IColleagueRepository repository)
        : base(mapper, logger, repository)
    {
    }
}
