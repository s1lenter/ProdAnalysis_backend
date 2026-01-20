using Microsoft.AspNetCore.Mvc;
using ProductionAnalysisBackend.Services.Excel;

namespace ProductionAnalysisBackend.Controllers;

[ApiController]
[Route("api/production-analysis/excel")]
public class ProductionAnalysisExcelController : ControllerBase
{
    private readonly IProductionAnalysisExcelService _service;

    public ProductionAnalysisExcelController(
        IProductionAnalysisExcelService service)
    {
        _service = service;
    }

    [HttpGet("{analysisId}")]
    public async Task<IActionResult> Download(int analysisId)
    {
        var file = await _service.GenerateExcel(analysisId);

        return File(
            file,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "production_analysis.xlsx"
        );
    }
}
