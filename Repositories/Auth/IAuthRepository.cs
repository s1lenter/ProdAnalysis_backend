using ProductionAnalysisBackend.Dto;
using ProductionAnalysisBackend.Models;

namespace ProductionAnalysisBackend.Repositories;

public interface IAuthRepository
{
    public Task RegisterAsync(User user);
    
    public Task<User?> GetUserAsync(LoginDto userLoginDto);
    
    // public Task<User?> GetUserAync(RegisterDto user);
    //
    // public Task<User?> GetUserAync(LoginDto user);

    public Task<User?> GetUserAsync(int id);

    // public Task CreateUserAsync(User userDto);

    public Task SaveRefreshTokenAsync(RefreshTokenRequestDto refreshTokenRequestDto);

    public Task<RefreshToken> GetRefreshTokenAsync(string token);

    public Task<RefreshToken?> GetRefreshTokenAsync(int userId);

    // public Task<User?> GetUserByUsernameAsync(string userName);

    // public Task<User?> GetUserByEmailAsync(string email);

    public Task DeleteRefreshTokenAsync(int userId);
}