namespace ProductionAnalysisBackend.Services.Excel;

public interface IProductionAnalysisExcelService
{
    Task<byte[]> GenerateExcel(int analysisId);
}