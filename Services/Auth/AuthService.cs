using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductionAnalysisBackend.Dto;
using ProductionAnalysisBackend.Models;
using ProductionAnalysisBackend.Repositories;

namespace ProductionAnalysisBackend.Services;

public class AuthService : IAuthService
{
    private IMapper _mapper;
    private IAuthRepository _repository;
    private ITokenService _tokenService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IPersonalKeyHasher _personalKeyHasher;

    public AuthService(IMapper mapper, AppDbContext context, ITokenService tokenService, IHttpContextAccessor httpContextAccessor,  IPersonalKeyHasher personalKeyHasher)
    {
        _mapper = mapper;
        _repository = new AuthRepository(context);
        _tokenService = tokenService;
        _httpContextAccessor = httpContextAccessor;
        _personalKeyHasher = personalKeyHasher;
    }

    public async Task<Result<string>> RegisterAsync(RegisterDto registerDto)
    {
        var newUser =  _mapper.Map<User>(registerDto);
        newUser.DepartmentId = 1;
        newUser.RoleId = 1;
        newUser.PersonalKey = Guid.NewGuid().ToString();
        await _repository.RegisterAsync(newUser);
        return Result<string>.Success("User created");
    }

    public async Task<Result<TokenResponseDto?>> LoginAsync(LoginDto userLoginDto, HttpContext httpContext)
    {
        var errorRes = new List<Dictionary<string, string>>();

        var user = await _repository.GetUserAsync(userLoginDto);
        if (user is null)
            return Result<TokenResponseDto?>.Failure("Такого пользователя не существует");

        if (ValidatePersonalKey(user, userLoginDto.PersonalKey))
        {
            var accessToken = _tokenService.CreateToken(user);
            httpContext.Response.Cookies.Append("token", accessToken);
            var refreshToken = await _tokenService.GenearateAndSaveRefreshTokenAsync(user);
            return Result<TokenResponseDto?>.Success(new TokenResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });
        }
        return Result<TokenResponseDto?>.Failure("Неверный пароль");
    }
    
    private bool ValidatePersonalKey(User user, string inputKey)
    {
        return _personalKeyHasher.Verify(
            inputKey, user.PersonalKey);
    }
    
    public async Task<Result<string>> LogoutAsync(HttpContext context)
    {
        var errorRes = new List<Dictionary<string, string>>();

        var currantUserId = int.Parse(context.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        
        var user = await _repository.GetUserAsync(currantUserId);
        if (user == null)
            return Result<string>.Failure("Такого пользователя не существует");

        context.Response.Cookies.Delete("token");

        await _repository.DeleteRefreshTokenAsync(user.Id);
        return Result<string>.Success("");
    }

    public async Task<Result<string>> RefreshAccessTokenAsync(string accessToken, HttpContext httpContext)
    {
        var errorRes = new List<Dictionary<string, string>>();

        var principal = await _tokenService.GetClaimsFromToken(accessToken);
        var userId = principal.Claims.FirstOrDefault(c =>
            c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")!.Value;
        var savedRefreshToken = await _repository.GetRefreshTokenAsync(int.Parse(userId));

        if (savedRefreshToken is null)
            return Result<string>.Failure("Пользователь не имеет refresh токен");
        
        if (savedRefreshToken.RefreshTokenExpiryTime < DateTime.UtcNow)
            return Result<string>.Failure("Истек срок действия refresh токена");

        var newAccessToken = _tokenService.UpdateAccessToken(principal.Claims);

        httpContext.Response.Cookies.Delete("token");
        httpContext.Response.Cookies.Append("token", newAccessToken);

        return Result<string>.Success(newAccessToken);
    }
}