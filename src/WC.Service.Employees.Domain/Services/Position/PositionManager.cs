using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using WC.Library.Domain.Services;
using WC.Service.Employees.Data.Models;
using WC.Service.Employees.Data.Repositories;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.Domain.Services.Position;

public class PositionManager
    : DataManagerBase<PositionManager, IPositionRepository, PositionModel, PositionEntity>,
        IPositionManager
{
    public PositionManager(
        IMapper mapper,
        ILogger<PositionManager> logger,
        IPositionRepository repository,
        IEnumerable<IValidator> validators)
        : base(mapper, logger, repository, validators)
    {
    }
}
