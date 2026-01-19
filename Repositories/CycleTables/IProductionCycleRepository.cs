using ProductionAnalysisBackend.Models;

namespace ProductionAnalysisBackend.Repositories.CycleTables;

public interface IProductionCycleRepository
{
    Task CreateAnalysis(ProductionCycleAnalysis analysis);
    Task<bool> ProductExists(int productId);
    Task<bool> DepartmentExists(int departmentId);
    Task<bool> UserExists(int userId);
    Task<ProductionCycleAnalysis?> GetAnalysis(int id);
    Task<CycleOperation?> GetOperation(int operationId);
    Task Save();
}