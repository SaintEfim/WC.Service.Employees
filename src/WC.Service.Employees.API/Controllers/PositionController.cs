using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using WC.Library.Web.Controllers;
using WC.Library.Web.Models;
using WC.Service.Employees.API.Models.Position;
using WC.Service.Employees.Domain.Models;
using WC.Service.Employees.Domain.Services.Position;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WC.Service.Employees.API.Controllers;

/// <summary>
///     The position management controller.
/// </summary>
[Route("api/v1/positions")]
public class PositionController
    : CrudApiControllerBase<PositionController, IPositionManager, IPositionProvider, PositionModel, PositionDto>
{
    /// <inheritdoc/>
    public PositionController(
        IMapper mapper,
        ILogger<PositionController> logger,
        IPositionManager manager,
        IPositionProvider provider)
        : base(mapper, logger, manager, provider)
    {
    }

    /// <summary>
    ///     Retrieves a list of positions.
    /// </summary>
    /// <param name="withIncludes">Specifies whether related entities should be included in the query.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    /// <returns></returns>
    [HttpGet]
    [OpenApiOperation(nameof(PositionGet))]
    [SwaggerResponse(Status200OK, typeof(List<PositionDto>))]
    public async Task<ActionResult<List<PositionDto>>> PositionGet(
        bool withIncludes = false,
        CancellationToken cancellationToken = default)
    {
        return Ok(await GetMany(withIncludes, cancellationToken));
    }

    /// <summary>
    ///     Retrieves a position by its ID.
    /// </summary>
    /// <param name="id">The ID of the position to retrieve.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    /// <returns></returns>
    [HttpGet("{id:guid}", Name = nameof(PositionGetById))]
    [OpenApiOperation(nameof(PositionGetById))]
    [SwaggerResponse(Status200OK, typeof(PositionDto))]
    [SwaggerResponse(Status404NotFound, typeof(ErrorDto))]
    public async Task<ActionResult<PositionDto>> PositionGetById(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return Ok(await GetOneById(id, true, cancellationToken));
    }

    /// <summary>
    ///     Creates new position.
    /// </summary>
    /// <param name="payload">The position content.</param>
    /// <param name="cancellationToken">The operation cancellation token</param>
    /// <returns>The result of creation. <see cref="CreateActionResultDto"/></returns>
    [HttpPost]
    [OpenApiOperation(nameof(PositionCreate))]
    [SwaggerResponse(Status201Created, typeof(CreateActionResultDto))]
    public Task<IActionResult> PositionCreate(
        [FromBody] PositionCreateDto payload,
        CancellationToken cancellationToken = default)
    {
        return Create<PositionCreateDto, CreateActionResultDto>(payload, nameof(PositionGetById), cancellationToken);
    }

    /// <summary>
    ///     Updates a position by ID.
    /// </summary>
    /// <param name="id">The ID of the position to update.</param>
    /// <param name="patchDocument">The JSON patch document containing updates.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    /// <returns></returns>
    [HttpPatch("{id:guid}")]
    [OpenApiOperation(nameof(PositionUpdate))]
    [SwaggerResponse(Status200OK, typeof(void))]
    [SwaggerResponse(Status404NotFound, typeof(ErrorDto))]
    public async Task<IActionResult> PositionUpdate(
        Guid id,
        [FromBody] JsonPatchDocument<PositionDto> patchDocument,
        CancellationToken cancellationToken = default)
    {
        return Ok(await Update(id, patchDocument, cancellationToken));
    }

    /// <summary>
    ///     Deletes a position by ID.
    /// </summary>
    /// <param name="id">The ID of the position to delete.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    [OpenApiOperation(nameof(PositionDelete))]
    [SwaggerResponse(Status200OK, typeof(void))]
    [SwaggerResponse(Status204NoContent, typeof(ErrorDto))]
    [SwaggerResponse(Status404NotFound, typeof(ErrorDto))]
    [SwaggerResponse(Status400BadRequest, typeof(ErrorDto))]
    [SwaggerResponse(Status409Conflict, typeof(ErrorDto))]
    public async Task<IActionResult> PositionDelete(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return Ok(await Delete(id, cancellationToken));
    }
}
