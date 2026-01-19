using ProductionAnalysisBackend.Dto.CycleTables;

namespace ProductionAnalysisBackend.Services.CycleTables;

public interface IProductionCycleService
{
    Task Create(CycleAnalysisCreateDto dto);
    Task<ProductionCycleTableDto> GetTable(int analysisId);
    Task UpdateOperation(UpdateCycleOperationDto dto);
}