using FiscalLabService.App.Dtos.Request;
using FiscalLabService.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiscalLabService.API.Controllers;

[ApiController]
[Route("accounts")]
public class AccountController : ControllerBase
{
    private readonly IIdentityService _identityService;

    public AccountController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] RegisterUserRequest registerUserRequest)
    {
        var result = await _identityService.RegisterUserAsync(registerUserRequest);
        if (result.IsSuccess)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
    {
        var result = await _identityService.LoginAsync(loginRequest);
        if (result.IsSuccess)
        {
            return Ok(result);
        }

        return Unauthorized(result);
    }
    
}