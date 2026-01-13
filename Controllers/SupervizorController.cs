using Microsoft.AspNetCore.Mvc;
using ProductionAnalysisBackend.Dto.Supervizor;
using ProductionAnalysisBackend.Models;
using ProductionAnalysisBackend.Services.Supervizor;

namespace ProductionAnalysisBackend.Controllers;

[ApiController]
[Route("/api")]
public class SupervizorController : ControllerBase
{
    private readonly ISupervizorService _supervizorService;
    public SupervizorController(ISupervizorService supervizorService)
    {
        _supervizorService = supervizorService;
    }

    [HttpPost("shift/create")]
    public async Task<IActionResult> CreateShift([FromForm] ShiftCreateDto shiftCreateDto)
    {
        var result = await _supervizorService.CreateShiftAsync(shiftCreateDto);
        if (!result.IsSuccess)
            return BadRequest(result.Error);
        return Ok();
    }
    
    [HttpPost("shift/create")]
    public async Task<IActionResult> Create([FromForm] ShiftCreateDto shiftCreateDto)
    {
        var result = await _supervizorService.CreateShiftAsync(shiftCreateDto);
        return Ok();
    }
}