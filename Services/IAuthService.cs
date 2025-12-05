using Microsoft.AspNetCore.Mvc;
using ProductionAnalysisBackend.Dto;

namespace ProductionAnalysisBackend.Services;

public interface IAuthService
{
    public Task<Result<string>> RegisterAsync(RegisterDto registerDto);

    public Task<Result<TokenResponseDto?>> LoginAsync(LoginDto userLoginDto, HttpContext httpContext);
    
    public Task<Result<string>> LogoutAsync(HttpContext context);

    public Task<Result<string>> RefreshAccessTokenAsync(string accessToken, HttpContext httpContext);
}