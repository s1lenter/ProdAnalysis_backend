using Microsoft.AspNetCore.Identity;
using ProductionAnalysisBackend.Models;

namespace ProductionAnalysisBackend;

public static class PasswordHasher
{
    public static string GetHash(string password)
    {
        var hasher = new PasswordHasher<User>();
        return hasher.HashPassword(null, password);
    }
}