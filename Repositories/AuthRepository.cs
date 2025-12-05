using Microsoft.EntityFrameworkCore;
using ProductionAnalysisBackend.Dto;
using ProductionAnalysisBackend.Models;

namespace ProductionAnalysisBackend.Repositories;

public class AuthRepository : IAuthRepository
{
    private AppDbContext _context;
    private IAuthRepository _authRepositoryImplementation;

    public AuthRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task RegisterAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetUserAsync(LoginDto userLoginDto)
    {
        return await _context.Users.FirstOrDefaultAsync(user => 
            user.Username == userLoginDto.PersonalKey); 
    }

    public async Task CreateUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        
        await _context.SaveChangesAsync();
    }

    public async Task SaveRefreshTokenAsync(RefreshTokenRequestDto refreshTokenRequestDto)
    {
        var existToken = await _context.RefreshTokens.FirstOrDefaultAsync(t => t.UserId == refreshTokenRequestDto.UserId);
        if (existToken is not null)
        {
            existToken.Token = refreshTokenRequestDto.RefreshToken;
            existToken.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(10);
        }
        else
        {
            var refreshToken = new RefreshToken()
            {
                Token = refreshTokenRequestDto.RefreshToken,
                UserId = refreshTokenRequestDto.UserId,
                RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(10)
            };
            await _context.RefreshTokens.AddAsync(refreshToken);
        }
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetUserAync(RegisterDto userDto)
    {
        return await GetUserByUsernameAsync(userDto.PersonalKey);
    }

    public async Task<User?> GetUserAync(LoginDto userDto)
    {
        return await GetUserByUsernameAsync(userDto.PersonalKey);
    }

    public async Task<User?> GetUserAsync(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetUserByUsernameAsync(string userName)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Username == userName);
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<RefreshToken?> GetRefreshTokenAsync(string token)
    {
        return await _context.RefreshTokens.FirstOrDefaultAsync(t => t.Token == token);
    }

    public async Task<RefreshToken?> GetRefreshTokenAsync(int userId)
    {
        return await _context.RefreshTokens.FirstOrDefaultAsync(t => t.UserId == userId);
    }

    public async Task DeleteRefreshTokenAsync(int userId)
    {
        var token = await _context.RefreshTokens.FirstOrDefaultAsync(t => t.UserId == userId);
        if (token is not null)
            _context.RefreshTokens.Remove(token);
    }
}