using Microsoft.AspNetCore.Mvc;
using ProductionAnalysisBackend.Dto.Supervisor;
using ProductionAnalysisBackend.Models;
using ProductionAnalysisBackend.Services.Supervisor;

namespace ProductionAnalysisBackend.Controllers;

[ApiController]
[Route("/api")]
public class SupervisorController : ControllerBase
{
    private readonly ISupervisorService _supervisorService;
    public SupervisorController(ISupervisorService supervisorService)
    {
        _supervisorService = supervisorService;
    }

    [HttpPost("shift/create")]
    public async Task<IActionResult> CreateShift([FromForm] ShiftCreateDto shiftCreateDto)
    {
        var result = await _supervisorService.CreateShiftAsync(shiftCreateDto);
        if (!result.IsSuccess)
            return BadRequest(result.Error);
        return Ok();
    }
    
    [HttpGet("shifts")]
    public async Task<IActionResult> Get()
    {
        var result = await _supervisorService.GetAsync();
        if (!result.IsSuccess)
            return BadRequest(result.Error);
        return Ok(result.Value);
    }
}