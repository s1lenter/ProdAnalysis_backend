using Microsoft.AspNetCore.Mvc;
using ProductionAnalysisBackend.Services.Admin;

namespace ProductionAnalysisBackend.Controllers;

[ApiController]
[Route("/api/admin")]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;
    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }
}