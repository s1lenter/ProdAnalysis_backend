namespace ProductionAnalysisBackend.Services;

public class PersonalKeyGenerator : IPersonalKeyGenerator
{
    public string Generate()
    {
        return Guid.NewGuid().ToString("N");
    }
}