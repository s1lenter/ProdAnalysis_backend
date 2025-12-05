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

    public AuthService(IMapper mapper, AppDbContext context, ITokenService tokenService)
    {
        _mapper = mapper;
        _repository = new AuthRepository(context);
        _tokenService = tokenService;
    }

    public async Task<Result<string>> RegisterAsync(RegisterDto registerDto)
    {
        var newUser =  _mapper.Map<User>(registerDto);
        newUser.DepartamentId = 1;
        newUser.RoleId = 1;
        await _repository.RegisterAsync(newUser);
        return Result<string>.Success("User created");
    }

    public async Task<Result<TokenResponseDto?>> LoginAsync(LoginDto userLoginDto, HttpContext httpContext)
    {
        var errorRes = new List<Dictionary<string, string>>();

        var user = await _repository.GetUserAsync(userLoginDto);
        if (user is null)
            return Result<TokenResponseDto?>.Failure("Такого пользователя не существует");

        if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, userLoginDto.Password) 
            == PasswordVerificationResult.Success)
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
}