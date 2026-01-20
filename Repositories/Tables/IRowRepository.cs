using ProductionAnalysisBackend.Models;

namespace ProductionAnalysisBackend.Repositories.Tables;

public interface IRowRepository
{
    Task<Row?> GetByIdAsync(int id);
    Task UpdateAsync(Row row);
    Task AddDeviationAsync(Deviation deviation);
    public Task<Row?> GetRowWithDeviation(int rowId);
    public Task Save();
    public Task RemoveDeviation(Deviation deviation);
    public Task<List<Row>> GetTableRows(int productionAnalysisId);

    public Task<ProductionAnalysis> GetAnalysisWithShift(int shiftId);
    
    public Task<ProductionAnalysis> GetAnalysisWithId(int tableId);
    Task<Product> GetProduct(int paId);
}