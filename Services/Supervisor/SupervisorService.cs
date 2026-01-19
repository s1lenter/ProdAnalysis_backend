using System.Security.Claims;
using AutoMapper;
using ProductionAnalysisBackend.Dto;
using ProductionAnalysisBackend.Dto.Supervisor;
using ProductionAnalysisBackend.Models;
using ProductionAnalysisBackend.Repositories.Supervisor;

namespace ProductionAnalysisBackend.Services.Supervisor;

public class SupervisorService : ISupervisorService
{
    private readonly ISupervisorRepository _repository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<SupervisorService> _logger;
    private readonly IMapper _mapper;
    
    public SupervisorService(AppDbContext context, ILogger<SupervisorService> logger, 
        IHttpContextAccessor httpContextAccessor, IMapper mapper)
    {
        _logger = logger;
        _repository = new SupervisorRepository(context);
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
    }

    public async Task<Result<ShiftDto>> GetAsync()
    {
        var user = _httpContextAccessor.HttpContext?.User;

        if (user is null)
        {
            _logger.LogError("Текущий пользователь не авторизован");
            return Result<ShiftDto>.Failure("Текущий пользователь не авторизован");
        }
        
        var userId = int.Parse(user.FindFirst(ClaimTypes.NameIdentifier).Value);

        var shift = await _repository.GetByUserAsync(userId);

        if (shift is null)
            return Result<ShiftDto>.Failure("Смена не начата");
        
        var result =_mapper.Map<Shift, ShiftDto>(shift);

        var department = await _repository.GetDepartmentAsync(result.DepartmentId);
        var operatorUser =  await _repository.GetOperatorAsync(result.OperatorId);
        result.DepartmentName = department.Name;
        result.OperatorName = $"{operatorUser.LastName} {operatorUser.FirstName[0]}. {operatorUser.MiddleName[0]}.";
        result.ShiftType = shift.StartTime.Hour == 8 ? "Дневная" : "Вечерняя";
        shift.EndTime = shift.StartTime.AddHours(8);
        
        return Result<ShiftDto>.Success(result);
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
        
        var startTime = DateTime.UtcNow.Date.AddHours(8);

        if (shiftCreateDto.ShiftType == "Ночная")
            startTime.AddHours(8);
        
        var shift = new Shift()
        {
            Date = DateTime.UtcNow.Date,
            StartTime = startTime,
            Duration = duration, // как-то должна устанавливаться длительность смены
            EndTime = startTime.AddHours(duration),
            Status = "Создана",
            Department = await _repository.GetDepartmentAsync(shiftCreateDto.DepartmentId),
            CreatorId = userId,
            OperatorId = await _repository.GetOperatorIdAsync(shiftCreateDto.OperatorId)
        };
        await _repository.CreateShiftAsync(shift);
        _logger.LogInformation("ЛОГИРУЮЮЮЮЮЮЮЮЮЮ");
        return Result<string>.Success("ok");
    }
    
    public async Task<List<UserDto>> GetByDepartment(int departmentId)
    {
        if (departmentId <= 0)
            throw new Exception("Некорректный departmentId");

        var users = await _repository.GetByDepartmentId(departmentId);

        return users.Select(u => new UserDto
        {
            Id = u.Id,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Email = u.Email,
            MiddleName = u.MiddleName,
        }).ToList();
    }

    public async Task CloseShiftAsync(int shiftId)
    {
        var shift = await _repository.GetAsync(shiftId);
        shift.Status = "Closed";
        await _repository.CloseShiftAsync(shift);
    }
}