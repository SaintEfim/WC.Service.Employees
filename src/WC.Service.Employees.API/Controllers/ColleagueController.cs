using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WC.Library.Web.Controllers;
using WC.Library.Web.Models;
using WC.Service.Employees.API.Models.Colleague;
using WC.Service.Employees.Domain.Models;
using WC.Service.Employees.Domain.Services.Colleague;
using Swashbuckle.AspNetCore.Annotations;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WC.Service.Employees.API.Controllers;

/// <summary>
///     The colleague management controller.
/// </summary>
[Route("api/[controller]")]
public class ColleagueController : CrudApiControllerBase<ColleagueController, IColleagueManager, IColleagueProvider,
    ColleagueModel, ColleagueDto>
{
    /// <inheritdoc />
    public ColleagueController(IMapper mapper, ILogger<ColleagueController> logger, IEnumerable<IValidator> validators,
        IColleagueManager manager, IColleagueProvider provider) : base(mapper, logger, validators, manager, provider)
    {
    }

    /// <summary>
    /// Retrieves a list of colleagues.
    /// </summary>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpGet]
    [SwaggerOperation(OperationId = nameof(ColleagueGet))]
    [SwaggerResponse(Status200OK, Type = typeof(List<ColleagueDto>))]
    public async Task<ActionResult<List<ColleagueDto>>> ColleagueGet(CancellationToken cancellationToken = default)
    {
        return Ok(await GetMany(cancellationToken));
    }

    /// <summary>
    /// Retrieves a colleague by its ID.
    /// </summary>
    /// <param name="id">The ID of the colleague to retrieve.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpGet("{id:guid}")]
    [SwaggerOperation(OperationId = nameof(ColleagueGetById))]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<ActionResult<ColleagueDto>> ColleagueGetById(Guid id,
        CancellationToken cancellationToken = default)
    {
        return Ok(await GetOneById(id, cancellationToken));
    }

    /// <summary>
    /// Creates a new colleague.
    /// </summary>
    /// <param name="colleague">The colleague data.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpPost]
    [SwaggerOperation(OperationId = nameof(ColleagueCreate))]
    [SwaggerResponse(Status200OK)]
    public async Task<IActionResult> ColleagueCreate(ColleagueDto colleague,
        CancellationToken cancellationToken = default)
    {
        return Ok(await Create(colleague, cancellationToken));
    }

    /// <summary>
    /// Updates a colleague by ID.
    /// </summary>
    /// <param name="id">The ID of the colleague to update.</param>
    /// <param name="patchDocument">The JSON patch document containing updates.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpPatch("{id:guid}")]
    [SwaggerOperation(OperationId = nameof(ColleagueUpdate))]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> ColleagueUpdate(Guid id, [FromBody] JsonPatchDocument<ColleagueDto> patchDocument,
        CancellationToken cancellationToken = default)
    {
        return Ok(await Update(id, patchDocument, cancellationToken));
    }

    /// <summary>
    /// Deletes a colleague by ID.
    /// </summary>
    /// <param name="id">The ID of the colleague to delete.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpDelete("{id:guid}")]
    [SwaggerOperation(OperationId = nameof(ColleagueDelete))]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status204NoContent, Type = typeof(ErrorDto))]
    [SwaggerResponse(Status404NotFound, Type = typeof(ErrorDto))]
    [SwaggerResponse(Status400BadRequest, Type = typeof(ErrorDto))]
    [SwaggerResponse(Status409Conflict, Type = typeof(ErrorDto))]
    public async Task<IActionResult> ColleagueDelete(Guid id, CancellationToken cancellationToken = default)
    {
        return Ok(await Delete(id, cancellationToken));
    }
}