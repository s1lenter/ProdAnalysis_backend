using Microsoft.AspNetCore.Mvc;
using ProductionAnalysisBackend.Services.Admin;

namespace ProductionAnalysisBackend.Controllers;

[ApiController]
[Route("/api")]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;
    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpGet("guide/{guideName}")]
    public async Task<IActionResult> GetGuide([FromRoute] string guideName)
    {
        var result = await _adminService.GetGuide(guideName);
        // if (!result.IsSuccess)
        //     return result.Error;
        return Ok(result.Value);
    }
}