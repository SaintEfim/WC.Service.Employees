using AutoMapper;
using Microsoft.Extensions.Logging;
using WC.Library.Domain.Services;
using WC.Service.Employees.Data.Models;
using WC.Service.Employees.Data.Repositories;
using WC.Service.Employees.Domain.Models;

namespace WC.Service.Employees.Domain.Services.Position;

public class PositionProvider : DataProviderBase<PositionProvider, IPositionRepository, PositionModel, PositionEntity>,
    IPositionProvider
{
    public PositionProvider(IMapper mapper, ILogger<PositionProvider> logger, IPositionRepository repository) : base(
        mapper, logger, repository)
    {
    }

    public async Task<PositionModel?> GetOneByName(string positionName,
        CancellationToken cancellationToken = default)
    {
        var positions = await Repository.Get(cancellationToken: cancellationToken);
        var position = positions.SingleOrDefault(x => x.Name == positionName);

        return Mapper.Map<PositionModel>(position);
    }
}