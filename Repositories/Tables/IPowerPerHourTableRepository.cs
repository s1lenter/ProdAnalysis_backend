using ProductionAnalysisBackend.Models;

namespace ProductionAnalysisBackend.Repositories.Tables;

public interface IPowerPerHourTableRepository
{
    public Task CreateProductionAnalysis(ProductionAnalysis productionAnalysis, int productId);
    public Task CreatePaProducts(int paId, int productId);
    public Task CreatePowerPerHour(Parameter parameter);
    
    public Task CreateRows(int id, int productId, int plan);
    public Task<Scenario> CreateScenario(string scenario);

    public Task<List<Row>> GetProductRows(
        int productionAnalysisId,
        int productId);

    public Task<Product> GetProduct(int productId);

    public Task<List<ProductionAnalysis>> GetAnalysisForUser(int userId);
    
    public Task<Scenario> GetScenario(int scenarioId);

    public Task<List<ProductionAnalysis>> GetAnalysisForSupervisor(int userId);
}