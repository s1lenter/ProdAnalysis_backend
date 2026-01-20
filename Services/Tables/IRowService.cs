using ProductionAnalysisBackend.Dto.Tables;

namespace ProductionAnalysisBackend.Services.Tables;

public interface IRowService
{
    Task SaveFactAsync(SaveFactRowDto dto);

    Task UpdateRow(UpdateRowDto dto);
    Task UpdateRows(List<UpdateRowDto> dtos);
    public Task<List<RowTableDto>> GetTableRows(int productionAnalysisId);

    public Task<ProductionAnalysisTableDto> GetTable(int shiftId);
}