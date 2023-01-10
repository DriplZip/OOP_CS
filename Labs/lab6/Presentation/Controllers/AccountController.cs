using System.Net;
using System.Security.Claims;
using BusinessLogic.Dto;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

#nullable disable

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _service;

    public AccountController(IAccountService service)
    {
        _service = service;
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(string username, string password)
    {
        AccountDto account = await _service.FindAccount(username, password);
        if (account is null) return AccessDenied();

        Claim[] claims = new Claim[]
        {
            new Claim(ClaimTypes.Name, account.login),
            new Claim(ClaimTypes.Sid, account.id.ToString()),
            new Claim(ClaimTypes.Role, account.role),
        };

        ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

        return Ok(account);
    }

    [Route("error")]
    [HttpGet]
    [HttpPost]
    public ActionResult AccessDenied()
    {
        Claim claim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role);

        return claim is not null
            ? this.StatusCode((int)HttpStatusCode.Forbidden, $"User with role {claim.Value} is not authorized")
            : this.Unauthorized("User is not authenticated");
    }
}