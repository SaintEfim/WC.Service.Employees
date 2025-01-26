using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using WC.Library.Web.Controllers;
using WC.Library.Web.Models;
using WC.Service.Employees.API.Models.Colleague;
using WC.Service.Employees.Domain.Models;
using WC.Service.Employees.Domain.Services.Colleague;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WC.Service.Employees.API.Controllers;

/// <summary>
///     The colleague management controller.
/// </summary>
[Route("api/v1/colleagues")]
public class ColleagueController
    : CrudApiControllerBase<ColleagueController, IColleagueManager, IColleagueProvider, ColleagueModel, ColleagueDto,
        ColleagueDetailDto>
{
    /// <inheritdoc/>
    public ColleagueController(
        IMapper mapper,
        ILogger<ColleagueController> logger,
        IColleagueManager manager,
        IColleagueProvider provider)
        : base(mapper, logger, manager, provider)
    {
    }

    /// <summary>
    ///     Retrieves a list of colleagues.
    /// </summary>
    /// <param name="withIncludes">Specifies whether related entities should be included in the query.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpGet]
    [Authorize(Roles = "Admin, User")]
    [OpenApiOperation(nameof(ColleagueGet))]
    [SwaggerResponse(Status200OK, typeof(List<ColleagueDto>))]
    public async Task<ActionResult<List<ColleagueDto>>> ColleagueGet(
        bool withIncludes = false,
        CancellationToken cancellationToken = default)
    {
        return Ok(await GetMany(withIncludes, cancellationToken: cancellationToken));
    }

    /// <summary>
    ///     Retrieves a colleague by its ID.
    /// </summary>
    /// <param name="id">The ID of the colleague to retrieve.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpGet("{id:guid}", Name = nameof(ColleagueGetById))]
    [Authorize(Roles = "Admin, User")]
    [OpenApiOperation(nameof(ColleagueGetById))]
    [SwaggerResponse(Status200OK, typeof(ColleagueDetailDto))]
    [SwaggerResponse(Status404NotFound, typeof(ErrorDto))]
    public async Task<ActionResult<ColleagueDetailDto>> ColleagueGetById(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return Ok(await GetOneById(id, true, cancellationToken: cancellationToken));
    }

    /// <summary>
    ///     Creates a new colleague.
    /// </summary>
    /// <param name="payload">The colleague data.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [OpenApiOperation(nameof(ColleagueCreate))]
    [SwaggerResponse(Status201Created, typeof(CreateActionResultDto))]
    public Task<IActionResult> ColleagueCreate(
        [FromBody] ColleagueCreateDto payload,
        CancellationToken cancellationToken = default)
    {
        return Create<ColleagueCreateDto, CreateActionResultDto>(payload, nameof(ColleagueGetById),
            cancellationToken: cancellationToken);
    }

    /// <summary>
    ///     Updates a colleague by ID.
    /// </summary>
    /// <param name="id">The ID of the colleague to update.</param>
    /// <param name="patchDocument">The JSON patch document containing updates.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "Admin")]
    [OpenApiOperation(nameof(ColleagueUpdate))]
    [SwaggerResponse(Status200OK, typeof(void))]
    [SwaggerResponse(Status404NotFound, typeof(ErrorDto))]
    public Task<IActionResult> ColleagueUpdate(
        Guid id,
        [FromBody] JsonPatchDocument<ColleagueDto> patchDocument,
        CancellationToken cancellationToken = default)
    {
        return Update(id, patchDocument, cancellationToken: cancellationToken);
    }

    /// <summary>
    ///     Deletes a colleague by ID.
    /// </summary>
    /// <param name="id">The ID of the colleague to delete.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    [SwaggerResponse(Status204NoContent, typeof(void))]
    [SwaggerResponse(Status404NotFound, typeof(ErrorDto))]
    [SwaggerResponse(Status409Conflict, typeof(ErrorDto))]
    public Task<IActionResult> ColleagueDelete(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return Delete(id, cancellationToken: cancellationToken);
    }
}
