using Microsoft.Extensions.Logging;
using WC.Service.Employees.Domain.Models;
using WC.Service.Employees.Domain.Services.Position;

namespace WC.Service.Employees.CreatePosition;

public class CreatePosition
{
    private readonly IPositionManager _positionManager;
    private readonly ILogger<CreatePosition> _logger;

    public CreatePosition(
        ILogger<CreatePosition> logger,
        IPositionManager positionManager)
    {
        _positionManager = positionManager;
        _logger = logger;
    }

    public async Task Create(
        CancellationToken cancellationToken = default)
    {
        var registrationPayload = new PositionModel
        {
            Id = Guid.TryParse(Environment.GetEnvironmentVariable("ADMIN_POSITION_ID"), out var positionId)
                ? positionId
                : Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Name = Environment.GetEnvironmentVariable("ADMIN_POSITION_NAME") ?? "Администратор"
        };

        try
        {
            await _positionManager.Create(registrationPayload, cancellationToken: cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
}
