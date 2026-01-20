using System.Security.Claims;
using AutoMapper;
using ProductionAnalysisBackend.Dto.Tables;
using ProductionAnalysisBackend.Models;
using ProductionAnalysisBackend.Repositories.Supervisor;
using ProductionAnalysisBackend.Repositories.Tables;
using ProductionAnalysisBackend.Services.Supervisor;

namespace ProductionAnalysisBackend.Services.Tables;

public class PowerPerHourTableService : IPowerPerHourTableService
{
    private readonly PowerPerHourTableRepository _repository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<PowerPerHourTableService> _logger;
    private readonly IMapper _mapper;
    
    public PowerPerHourTableService(AppDbContext context, ILogger<PowerPerHourTableService> logger, 
        IHttpContextAccessor httpContextAccessor, IMapper mapper)
    {
        _logger = logger;
        _repository = new PowerPerHourTableRepository(context);
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
    }
    
    public async Task<int> Create(PowerPerHourTableCreateDto dto)
    {
        var user = _httpContextAccessor.HttpContext?.User;
        if (user == null)
            throw new Exception("User not authorized");

        var userId = int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        // 1️⃣ создаём сценарий
        var scenario = await _repository.CreateScenario(dto.ScenarioName);

        // 2️⃣ создаём ProductionAnalysis
        var analysis = new ProductionAnalysis
        {
            DepartmentId = dto.DepartmentId,
            OperatorId = dto.OperatorId,
            ShiftId = dto.ShiftId,
            ScenarioId = scenario.Id,
            CreatedAt = DateTime.UtcNow,
            CreatorId = userId,
            Status = "В работе"
        };

        await _repository.CreateProductionAnalysis(analysis, dto.ProductId);
        
        await _repository.CreatePaProducts(analysis.Id, dto.ProductId);

        // 3️⃣ создаём параметры (Power per hour)
        var parameters = new Parameter
        {
            ProductionAnalysisId = analysis.Id,
            PowerPerHour = dto.PowerPerHour,
            DailyTarget = dto.DailyTarget
        };

        await _repository.CreatePowerPerHour(parameters);

        // 4️⃣ создаём строки (ПОКА МИНИМАЛЬНО)
        await _repository.CreateRows(analysis.Id, dto.ProductId, parameters.DailyTarget / 8);
        
        return analysis.Id; 
    }
    
    public async Task<ProductAnalysisTableDto> GetProductTable(
        int productionAnalysisId,
        int productId)
    {
        var rows = await _repository.GetProductRows(
            productionAnalysisId, productId);

        var product = await _repository.GetProduct(productId);

        int planCumulative = 0;
        int factCumulative = 0;

        var resultRows = new List<ProductAnalysisRowDto>();

        foreach (var r in rows)
        {
            planCumulative += r.PlanQTY;
            factCumulative += r.FactQTY;

            var d = r.Deviations.FirstOrDefault();

            resultRows.Add(new ProductAnalysisRowDto
            {
                RowId = r.Id,
                WorkInterval = r.WorkInterval.Name,

                PlanQTY = r.PlanQTY,
                PlanCumulative = planCumulative,

                FactQTY = r.FactQTY,

                Deviation = r.FactQTY - r.PlanQTY,

                DowntimeMinutes = r.DowntimeMinutes,

                ReasonGroup = d?.ReasonGroup?.Name,
                Responsible = d?.ResponsibleUser?.FirstName +  " " + d?.ResponsibleUser?.LastName +  " " + d?.ResponsibleUser?.MiddleName,

                Comment = d?.Comment,
                TakenMeasures = d?.TakenMeasures
            });
        }

        return new ProductAnalysisTableDto
        {
            ProductId = product.Id,
            ProductName = product.Name,
            Rows = resultRows
        };
    }
}