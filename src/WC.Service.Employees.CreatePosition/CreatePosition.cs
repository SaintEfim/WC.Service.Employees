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

    private static readonly string AdminPositionName = Environment.GetEnvironmentVariable("ADMIN_POSITION_NAME") ?? "Администратор";

    public async Task Create(
        CancellationToken cancellationToken = default)
    {
        var namesPosition = (Environment.GetEnvironmentVariable("POSITION_NAMES") ?? AdminPositionName)
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(domain => domain.Trim())
            .ToArray();

        var adminId = Guid.TryParse(Environment.GetEnvironmentVariable("ADMIN_POSITION_ID"), out var positionId)
            ? positionId
            : Guid.Parse("00000000-0000-0000-0000-000000000001");

        var currentNumber = 2;
        var myDict = new Dictionary<string, Guid>();

        foreach (var name in namesPosition)
        {
            if (name == AdminPositionName)
            {
                myDict[name] = adminId;
            }
            else
            {
                var newId = new Guid($"00000000-0000-0000-0000-{currentNumber:D12}");
                myDict[name] = newId;
                currentNumber++;
            }
        }

        foreach (var position in myDict)
        {
            _logger.LogInformation($"{position.Key}: {position.Value}");
        }

        var positionModels = myDict.Select(entry => new PositionModel
            {
                Id = entry.Value,
                Name = entry.Key
            })
            .ToList();

        foreach (var positionModel in positionModels)
        {
            try
            {
                await _positionManager.Create(positionModel, cancellationToken: cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }
    }
}
