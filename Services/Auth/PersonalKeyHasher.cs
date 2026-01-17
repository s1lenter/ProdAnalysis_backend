using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace ProductionAnalysisBackend.Services;

public class PersonalKeyHasher : IPersonalKeyHasher
{
    public string Hash(string key)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(16);

        var hash = KeyDerivation.Pbkdf2(
            password: key,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100_000,
            numBytesRequested: 32);

        return $"{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
    }

    public bool Verify(string key, string hash)
    {
        var parts = hash.Split('.');
        var salt = Convert.FromBase64String(parts[0]);
        var expectedHash = Convert.FromBase64String(parts[1]);

        var actualHash = KeyDerivation.Pbkdf2(
            key,
            salt,
            KeyDerivationPrf.HMACSHA256,
            100_000,
            32);

        return CryptographicOperations.FixedTimeEquals(
            actualHash, expectedHash);
    }
}