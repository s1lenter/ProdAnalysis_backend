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
    public async Task<IActionResult> CreateShift([FromBody] ShiftCreateDto shiftCreateDto)
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

    [HttpGet("users/{departmentId}")]
    public async Task<IActionResult> GetByDepartment(int departmentId)
    {
        var users = await _supervisorService.GetByDepartment(departmentId);
        return Ok(users);
    }
    
    [HttpPut("shifts/close/{shiftId}")]
    public async Task<IActionResult> CloseShift(int shiftId)
    {
        await _supervisorService.CloseShiftAsync(shiftId);
        return Ok();
    }
    
}