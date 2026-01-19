using ProductionAnalysisBackend.Dto.Tables;

namespace ProductionAnalysisBackend.Services.Tables;

public interface IPowerPerHourTableService
{
    public Task<int> Create(PowerPerHourTableCreateDto dto);

    public Task<ProductAnalysisTableDto> GetProductTable(
        int productionAnalysisId,
        int productId);
}