using BusinessLogic.Dto;
using BusinessLogic.Services;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Constants;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InternalController : ControllerBase
{
    private readonly IAccountService _service;

    public InternalController(IAccountService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async Task<ActionResult<AccountDto>> CreateAccount([FromQuery] string login, [FromQuery] string password)
    {
        AccountDto account = await _service.Create(login, password);

        return Ok(account);
    }

    [HttpPost("grant-employee-status")]
    public async Task<ActionResult> GrantEmployeeStatus([FromQuery] Guid accountId)
    {
        AccountDto account = await _service.GrantEmployeeStatus(accountId);

        return Ok();
    }

    [HttpPost("grant-director-status")]
    public async Task<ActionResult> GrantDirectorStatus([FromQuery] Guid accountId)
    {
        AccountDto account = await _service.GrantDirectorStatus(accountId);

        return Ok();
    }
}