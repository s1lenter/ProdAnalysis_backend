using ProductionAnalysisBackend.Dto.CycleTables;
using ProductionAnalysisBackend.Models;
using ProductionAnalysisBackend.Repositories.CycleTables;

namespace ProductionAnalysisBackend.Services.CycleTables;

public class ProductionCycleService : IProductionCycleService
{
    private readonly IProductionCycleRepository _repository;

    public ProductionCycleService(AppDbContext context)
    {
        _repository = new ProductionCycleRepository(context);
    }

    public async Task Create(CycleAnalysisCreateDto dto)
    {
        // 🔒 базовые проверки
        if (!await _repository.ProductExists(dto.ProductId))
            throw new Exception("Продукт не найден");

        if (!await _repository.DepartmentExists(dto.DepartmentId))
            throw new Exception("Подразделение не найдено");

        if (!await _repository.UserExists(dto.OperatorId))
            throw new Exception("Исполнитель не найден");

        if (dto.CycleTimeMinutes <= 0)
            throw new Exception("Время цикла должно быть больше 0");

        if (dto.Operations == null || dto.Operations.Count == 0)
            throw new Exception("Не указаны операции цикла");

        // 🔥 КЛЮЧЕВАЯ БИЗНЕС-ПРОВЕРКА
        var totalOperationsTime = dto.Operations.Sum(o => o.DurationMinutes);

        if (totalOperationsTime != dto.CycleTimeMinutes)
        {
            throw new Exception(
                "Суммарное время операций должно быть равно времени цикла одной единицы продукции");
        }

        // 🧱 сборка сущности
        var analysis = new ProductionCycleAnalysis
        {
            ProductId = dto.ProductId,
            DepartmentId = dto.DepartmentId,
            OperatorId = dto.OperatorId,
            Date = dto.Date,
            CycleTimeMinutes = dto.CycleTimeMinutes,
            Operations = dto.Operations
                .Select((o, index) => new CycleOperation
                {
                    Name = o.Name,
                    DurationMinutes = o.DurationMinutes,
                    PlanQty = o.PlanQty,
                    Order = index + 1
                })
                .ToList()
        };

        await _repository.CreateAnalysis(analysis);
    }
    
    public async Task<ProductionCycleTableDto> GetTable(int analysisId)
    {
        var analysis = await _repository.GetAnalysis(analysisId);
        if (analysis == null)
            throw new Exception("Анализ не найден");

        return new ProductionCycleTableDto
        {
            AnalysisId = analysis.Id,
            ProductName = analysis.Product.Name,
            DepartmentName = analysis.Department.Name,
            OperatorName = analysis.Operator.LastName +  " " + analysis.Operator.FirstName + " " + analysis.Operator.MiddleName,
            Date = analysis.Date,
            CycleTimeMinutes = analysis.CycleTimeMinutes,

            Rows = analysis.Operations
                .OrderBy(o => o.Order)
                .Select(o => new CycleOperationRowDto
                {
                    OperationId = o.Id,
                    Order = o.Order,
                    Name = o.Name,
                    DurationMinutes = o.DurationMinutes,
                    PlanQty = o.PlanQty,

                    FactDurationMinutes = o.FactDurationMinutes,
                    Comment = o.Comment
                })
                .ToList()
        };
    }

    // ===== PUT =====
    public async Task UpdateOperation(UpdateCycleOperationDto dto)
    {
        var operation = await _repository.GetOperation(dto.OperationId);
        if (operation == null)
            throw new Exception("Операция не найдена");

        if (dto.FactDurationMinutes <= 0)
            throw new Exception("Фактическое время должно быть больше 0");

        operation.FactDurationMinutes = dto.FactDurationMinutes;
        operation.Comment = dto.Comment;

        await _repository.Save();
    }
}