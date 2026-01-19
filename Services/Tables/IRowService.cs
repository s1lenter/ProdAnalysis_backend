using ProductionAnalysisBackend.Dto.Tables;

namespace ProductionAnalysisBackend.Services.Tables;

public interface IRowService
{
    Task SaveFactAsync(SaveFactRowDto dto);

    Task UpdateRow(UpdateRowDto dto);
    public Task<List<RowTableDto>> GetTableRows(int productionAnalysisId);

    public Task<ProductionAnalysisTableDto> GetTable(int id);
}