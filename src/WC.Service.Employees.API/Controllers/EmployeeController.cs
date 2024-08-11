﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using WC.Library.Web.Controllers;
using WC.Library.Web.Models;
using WC.Service.Employees.API.Models.Employee;
using WC.Service.Employees.Domain.Models;
using WC.Service.Employees.Domain.Services.Employee;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WC.Service.Employees.API.Controllers;

/// <summary>
///     The employee management controller.
/// </summary>
[Route("api/v1/employees")]
public class EmployeeController
    : CrudApiControllerBase<EmployeeController, IEmployeeManager, IEmployeeProvider, EmployeeModel, EmployeeDto,
        EmployeeDetailDto>
{
    /// <inheritdoc/>
    public EmployeeController(
        IMapper mapper,
        ILogger<EmployeeController> logger,
        IEmployeeManager manager,
        IEmployeeProvider provider)
        : base(mapper, logger, manager, provider)
    {
    }

    /// <summary>
    ///     Retrieves a list of employees.
    /// </summary>
    /// <param name="withIncludes">Specifies whether related entities should be included in the query.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpGet]
    [OpenApiOperation(nameof(EmployeeGet))]
    [SwaggerResponse(Status200OK, typeof(List<EmployeeDto>))]
    public async Task<ActionResult<List<EmployeeDto>>> EmployeeGet(
        bool withIncludes = false,
        CancellationToken cancellationToken = default)
    {
        return Ok(await GetMany(withIncludes, cancellationToken));
    }

    /// <summary>
    ///     Retrieves a employee by its ID.
    /// </summary>
    /// <param name="id">The ID of the employee to retrieve.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpGet("{id:guid}", Name = nameof(EmployeeGetById))]
    [OpenApiOperation(nameof(EmployeeGetById))]
    [SwaggerResponse(Status200OK, typeof(EmployeeDetailDto))]
    [SwaggerResponse(Status404NotFound, typeof(ErrorDto))]
    public async Task<ActionResult<EmployeeDetailDto>> EmployeeGetById(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return Ok(await GetOneById(id, true, cancellationToken));
    }

    /// <summary>
    ///     Creates new employee.
    /// </summary>
    /// <param name="payload">The employee content.</param>
    /// <param name="cancellationToken">The operation cancellation token</param>
    /// <returns>The result of creation. <see cref="CreateActionResultDto"/></returns>
    [HttpPost]
    [OpenApiOperation(nameof(EmployeeCreate))]
    [SwaggerResponse(Status201Created, typeof(CreateActionResultDto))]
    public Task<IActionResult> EmployeeCreate(
        [FromBody] EmployeeCreateDto payload,
        CancellationToken cancellationToken = default)
    {
        return Create<EmployeeCreateDto, CreateActionResultDto>(payload, nameof(EmployeeGetById), cancellationToken);
    }

    /// <summary>
    ///     Updates a employee by ID.
    /// </summary>
    /// <param name="id">The ID of the employee to update.</param>
    /// <param name="patchDocument">The JSON patch document containing updates.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpPatch("{id:guid}")]
    [OpenApiOperation(nameof(EmployeeUpdate))]
    [SwaggerResponse(Status200OK, typeof(void))]
    [SwaggerResponse(Status404NotFound, typeof(ErrorDto))]
    public Task<IActionResult> EmployeeUpdate(
        Guid id,
        [FromBody] JsonPatchDocument<EmployeeDto> patchDocument,
        CancellationToken cancellationToken = default)
    {
        return Update(id, patchDocument, cancellationToken);
    }

    /// <summary>
    ///     Deletes a employee by ID.
    /// </summary>
    /// <param name="id">The ID of the employee to delete.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpDelete("{id:guid}")]
    [OpenApiOperation(nameof(EmployeeDelete))]
    [SwaggerResponse(Status204NoContent, typeof(void))]
    [SwaggerResponse(Status404NotFound, typeof(ErrorDto))]
    [SwaggerResponse(Status409Conflict, typeof(ErrorDto))]
    public Task<IActionResult> EmployeeDelete(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return Delete(id, cancellationToken);
    }
}
