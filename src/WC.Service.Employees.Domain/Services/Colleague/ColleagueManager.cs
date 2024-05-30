using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using WC.Library.Domain.Services;
using WC.Service.Employees.Data.Models;
using WC.Service.Employees.Data.Repositories;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.Domain.Services.Colleague;

public class ColleagueManager : DataManagerBase<ColleagueManager, IColleagueRepository, ColleagueModel, ColleagueEntity>
{
    public ColleagueManager(IMapper mapper, ILogger<ColleagueManager> logger, IColleagueRepository repository,
        IEnumerable<IValidator> validators) : base(mapper, logger, repository, validators)
    {
    }
}