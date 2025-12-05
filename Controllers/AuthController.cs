using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductionAnalysisBackend.Dto;
using ProductionAnalysisBackend.Services;

namespace ProductionAnalysisBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("/register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var result = await _authService.RegisterAsync(registerDto);
        if (result.IsSuccess)
            return Ok(result.Value);
        return BadRequest(result.Error);
    }

    [HttpPost("/login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginDto userLoginDto)
    {
        var response = await _authService.LoginAsync(userLoginDto, HttpContext);
        if (response.IsSuccess)
            return Ok(response.Value);
        return BadRequest(response.Error);

    }
    
    [Authorize]
    [HttpPost("/logout")]
    public async Task<IActionResult> Logout()
    {
        var response = await _authService.LogoutAsync(HttpContext);
        if (response is not null)
            return Ok();
        return BadRequest("Error!");
    }

    [HttpPost("/refresh")]
    public async Task<IActionResult> RefreshAccessToken()
    {
        var response = await _authService.RefreshAccessTokenAsync(
            HttpContext.Request.Headers.Authorization.ToString().Split()[1], HttpContext);
        if (response.IsSuccess)
            return Ok(response.Value);
        return BadRequest(response.Error);
    }

    [Authorize]
    [HttpGet("/secret")]
    public IActionResult GetSecret()
    {
        return Ok("You authorized!");
    }
}