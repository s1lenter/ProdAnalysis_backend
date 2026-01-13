using System.Security.Claims;
using ProductionAnalysisBackend.Dto.Supervizor;
using ProductionAnalysisBackend.Models;
using ProductionAnalysisBackend.Repositories.Supervizor;

namespace ProductionAnalysisBackend.Services.Supervizor;

public class SupervizorService : ISupervizorService
{
    private readonly ISupervizorRepository _repository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private ILogger<SupervizorService> _logger;
    
    public SupervizorService(AppDbContext context, ILogger<SupervizorService> logger, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _repository = new SupervizorRepository(context);
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Result<string>> CreateShiftAsync(ShiftCreateDto shiftCreateDto)
    {
        var duration = 8;

        var user = _httpContextAccessor.HttpContext?.User;

        if (user is null)
        {
            _logger.LogError("Текущий пользователь не авторизован");
            return Result<string>.Failure("Текущий пользователь не авторизован");
        }
        
        var userId = int.Parse(user.FindFirst(ClaimTypes.NameIdentifier).Value);
        
        var shift = new Shift()
        {
            Date = DateTime.UtcNow.Date,
            StartTime = shiftCreateDto.StartTime,
            Duration = duration, // как-то должна устанавливаться длительность смены
            EndTime = shiftCreateDto.StartTime.AddHours(duration),
            Status = "Создана",
            Department = await _repository.GetDepartmentAsync(shiftCreateDto.DepartmentId),
            CreatorId = userId,
            OperatorId = await _repository.GetOperatorIdAsync(shiftCreateDto.OperatorId),
        };
        await _repository.CreateShiftAsync(shift);
        _logger.LogInformation("ЛОГИРУЮЮЮЮЮЮЮЮЮЮ");
        return Result<string>.Success("ok");
    }
}