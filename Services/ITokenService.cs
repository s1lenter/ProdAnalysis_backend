using System.Security.Claims;
using ProductionAnalysisBackend.Dto;
using ProductionAnalysisBackend.Models;

namespace ProductionAnalysisBackend.Services;

public interface ITokenService
{
    public string CreateToken(User user);

    public Task<string> GenearateAndSaveRefreshTokenAsync(User user);

    public Task<ClaimsPrincipal> GetClaimsFromToken(string token);

    public Task<string> RefreshTokenAsync(RefreshTokenRequestDto refreshTokenRequestDto, User user);

    public string UpdateAccessToken(IEnumerable<Claim> claims);
}