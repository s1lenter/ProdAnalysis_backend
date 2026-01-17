namespace ProductionAnalysisBackend.Services;

public interface IPersonalKeyHasher
{
    string Hash(string key);
    bool Verify(string key, string hash);
}