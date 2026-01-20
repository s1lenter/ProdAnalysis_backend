using Microsoft.AspNetCore.Mvc;
using ProductionAnalysisBackend.Dto.Tables;
using ProductionAnalysisBackend.Repositories.Tables;
using ProductionAnalysisBackend.Services.Tables;

namespace ProductionAnalysisBackend.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PowerPerHourTableController : ControllerBase
{
    private IPowerPerHourTableService _powerPerHourTableService;
    private IRowService _service;

    public PowerPerHourTableController(IPowerPerHourTableService powerPerHourTableService, IRowService service)
    {
        _powerPerHourTableService = powerPerHourTableService;
        _service = service;
    }

    [HttpGet("operatorPA")]
    public async Task<IActionResult> GetPaForUser()
    {
        var result = await _powerPerHourTableService.GetAnalysisForUser();
        return Ok(result);
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateTable([FromBody] PowerPerHourTableCreateDto dto)
    {
        var id = await _powerPerHourTableService.Create(dto);
        return Ok(id);
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> UpdateRow([FromBody] UpdateRowDto dto)
    {
        await _service.UpdateRow(dto);
        return Ok();
    }

    
    // [HttpPost("fact")]
    // public async Task<IActionResult> SaveFact([FromBody] SaveFactRowDto dto)
    // {
    //     await _service.SaveFactAsync(dto);
    //     return Ok(new { message = "Fact data saved successfully" });
    // }
    
    // [HttpGet("table/{productionAnalysisId}")]
    // public async Task<IActionResult> GetTable(int productionAnalysisId)
    // {
    //     var table = await _service.GetTableRows(productionAnalysisId);
    //     return Ok(table);
    // }

    [HttpPost("fill/{tableId}")]
    public async Task<IActionResult> FillTable([FromBody] UpdateTableDto dto)
    {
        await _service.UpdateRows(dto.Rows);
        
        return Ok();
    }
    
    [HttpGet("{shiftId}/table")]
    public async Task<IActionResult> GetTableAll([FromRoute] int shiftId)
    {
        return Ok(await _service.GetTableByShift(shiftId));
    }
    
    [HttpGet("{paId}/product/{productId}/table")]
    public async Task<IActionResult> GetProductTable(
        int paId,
        int productId)
    {
        var table = await _powerPerHourTableService.GetProductTable(paId, productId);
        return Ok(table);
    }
    
    [HttpGet("table/{tableId}")]
    public async Task<IActionResult> GetTableById([FromRoute] int tableId)
    {
        return Ok(await _service.GetTableById(tableId));
    }
}