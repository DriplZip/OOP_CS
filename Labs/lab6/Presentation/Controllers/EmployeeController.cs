using BusinessLogic.Dto;
using BusinessLogic.Services;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Constants;
using Presentation.Models;

namespace Presentation.Controllers;

[ApiController]
[Authorize(Policy = PolicyName.DirectorPolicy)]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _service;

    public EmployeeController(IEmployeeService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async Task<ActionResult<EmployeeDto>> Create([FromBody] CreateEmployeeModel model)
    {
        EmployeeDto employee = await _service.CreateEmployee(model.name, model.surname);
        return Ok(employee);
    }

    [HttpPost("add-director")]
    public async Task<ActionResult> AddDirectorToEmployee([FromQuery] Guid directorId, [FromQuery] Guid employeeId)
    {
        await _service.AddDirector(employeeId, directorId);

        return Ok();
    }

    [HttpPut("add-message")]
    public async Task<ActionResult> AddMessageToEmployee([FromQuery] Guid employeeId, [FromQuery] Guid messageId)
    {
        await _service.AddMessage(employeeId, messageId);

        return Ok();
    }

    [HttpPut("add-subordinates")]
    public async Task<ActionResult> AddSubordinatesToEmployee(
        [FromQuery] Guid directorId,
        [FromQuery] Guid subordinatesId)
    {
        await _service.AddSubordinates(directorId, subordinatesId);

        return Ok();
    }

    [HttpGet("get-by-id")]
    public async Task<ActionResult<EmployeeDto>> GetEmployee([FromQuery] Guid id)
    {
        EmployeeDto employee = await _service.FindById(id);

        return employee;
    }

    [HttpDelete("delete")]
    public async Task<ActionResult> DeleteEmployee([FromQuery]Guid id)
    {
        await _service.Delete(id);

        return Ok();
    }
}