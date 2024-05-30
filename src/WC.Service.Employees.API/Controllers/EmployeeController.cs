using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WC.Library.Web.Controllers;
using WC.Library.Web.Models;
using WC.Service.Employees.API.Models.Employee;
using WC.Service.Employees.Domain.Models;
using WC.Service.Employees.Domain.Services.Employee;
using Swashbuckle.AspNetCore.Annotations;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WC.Service.Employees.API.Controllers;

/// <summary>
///     The employee management controller.
/// </summary>
[Route("api/[controller]")]
public class EmployeeController : CrudApiControllerBase<EmployeeController, IEmployeeManager, IEmployeeProvider,
    EmployeeModel, EmployeeDto>
{
    /// <inheritdoc />
    public EmployeeController(IMapper mapper, ILogger<EmployeeController> logger, IEnumerable<IValidator> validators,
        IEmployeeManager manager, IEmployeeProvider provider) : base(mapper, logger, validators, manager, provider)
    {
    }

    /// <summary>
    /// Retrieves a list of employees.
    /// </summary>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpGet]
    [SwaggerOperation(OperationId = nameof(EmployeeGet))]
    [SwaggerResponse(Status200OK, Type = typeof(List<EmployeeDto>))]
    public async Task<ActionResult<List<EmployeeDto>>> EmployeeGet(CancellationToken cancellationToken = default)
    {
        return Ok(await GetMany(cancellationToken));
    }

    /// <summary>
    /// Retrieves a employee by its ID.
    /// </summary>
    /// <param name="id">The ID of the employee to retrieve.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpGet("{id:guid}")]
    [SwaggerOperation(OperationId = nameof(EmployeeGetById))]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<ActionResult<EmployeeDto>> EmployeeGetById(Guid id,
        CancellationToken cancellationToken = default)
    {
        return Ok(await GetOneById(id, cancellationToken));
    }

    /// <summary>
    /// Creates a new employee.
    /// </summary>
    /// <param name="employee">The employee data.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpPost]
    [SwaggerOperation(OperationId = nameof(EmployeeCreate))]
    [SwaggerResponse(Status200OK)]
    public async Task<IActionResult> EmployeeCreate(EmployeeDto employee,
        CancellationToken cancellationToken = default)
    {
        return Ok(await Create(employee, cancellationToken));
    }

    /// <summary>
    /// Updates a employee by ID.
    /// </summary>
    /// <param name="id">The ID of the employee to update.</param>
    /// <param name="patchDocument">The JSON patch document containing updates.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpPatch("{id:guid}")]
    [SwaggerOperation(OperationId = nameof(EmployeeUpdate))]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> EmployeeUpdate(Guid id, [FromBody] JsonPatchDocument<EmployeeDto> patchDocument,
        CancellationToken cancellationToken = default)
    {
        return Ok(await Update(id, patchDocument, cancellationToken));
    }

    /// <summary>
    /// Deletes a employee by ID.
    /// </summary>
    /// <param name="id">The ID of the employee to delete.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpDelete("{id:guid}")]
    [SwaggerOperation(OperationId = nameof(EmployeeDelete))]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status204NoContent, Type = typeof(ErrorDto))]
    [SwaggerResponse(Status404NotFound, Type = typeof(ErrorDto))]
    [SwaggerResponse(Status400BadRequest, Type = typeof(ErrorDto))]
    [SwaggerResponse(Status409Conflict, Type = typeof(ErrorDto))]
    public async Task<IActionResult> EmployeeDelete(Guid id, CancellationToken cancellationToken = default)
    {
        return Ok(await Delete(id, cancellationToken));
    }
}