using ProductionAnalysisBackend.Dto.Excel;

namespace ProductionAnalysisBackend.Repositories.Excel;

public interface IProductionAnalysisExcelRepository
{
    Task<ProductionAnalysisExcelDto> GetAnalysisForExcel(int analysisId);
}