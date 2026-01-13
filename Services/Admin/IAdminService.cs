using ProductionAnalysisBackend.Models;

namespace ProductionAnalysisBackend.Services.Admin;

public interface IAdminService
{
    public Task<Result<object>> GetGuide(string guideName);
}