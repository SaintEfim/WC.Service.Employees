using Microsoft.Extensions.Logging;
using WC.Service.Employees.Domain.Models;
using WC.Service.Employees.Domain.Services.Position;

namespace WC.Service.Employees.CreatePosition;

public class CreatePosition
{
    private readonly IPositionManager _positionManager;
    private readonly ILogger<CreatePosition> _logger;
    private readonly AdminSettingsOptions _options;

    public CreatePosition(
        ILogger<CreatePosition> logger,
        IPositionManager positionManager,
        AdminSettingsOptions options)
    {
        _positionManager = positionManager;
        _options = options;
        _logger = logger;
    }

    public async Task Create(
        CancellationToken cancellationToken = default)
    {
        var namesPosition = _options.PositionNames;

        var adminId = _options.AdminPositionId;

        var currentNumber = 2;
        var myDict = new Dictionary<string, Guid>();

        foreach (var name in namesPosition)
        {
            if (name == "Администратор")
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
