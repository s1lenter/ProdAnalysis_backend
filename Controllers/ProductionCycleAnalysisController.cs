using Microsoft.AspNetCore.Mvc;
using ProductionAnalysisBackend.Dto.CycleTables;
using ProductionAnalysisBackend.Services.CycleTables;

namespace ProductionAnalysisBackend.Controllers;

[ApiController]
[Route("api/production-cycle-analysis")]
public class ProductionCycleAnalysisController : ControllerBase
{
    private readonly IProductionCycleService _service;

    public ProductionCycleAnalysisController(IProductionCycleService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(
        [FromBody] CycleAnalysisCreateDto dto)
    {
        await _service.Create(dto);
        return Ok();
    }
    
    // ===== GET TABLE =====
    [HttpGet("{id}/table")]
    public async Task<IActionResult> GetTable(int id)
    {
        return Ok(await _service.GetTable(id));
    }

    // ===== UPDATE ROW =====
    [HttpPut("operation")]
    public async Task<IActionResult> UpdateOperation(
        [FromBody] UpdateCycleOperationDto dto)
    {
        await _service.UpdateOperation(dto);
        return Ok();
    }
}