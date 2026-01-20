using ProductionAnalysisBackend.Dto.Tables;
using ProductionAnalysisBackend.Models;
using ProductionAnalysisBackend.Repositories.Tables;

namespace ProductionAnalysisBackend.Services.Tables;

public class RowService : IRowService
{
    private readonly IRowRepository _repository;

    public RowService(AppDbContext context)
    {
        _repository = new RowRepository(context);
    }

    public async Task SaveFactAsync(SaveFactRowDto dto)
    {
        var row = await _repository.GetByIdAsync(dto.RowId);
        if (row == null)
            throw new Exception("Row not found");

        // 1️⃣ сохраняем фактические показатели
        row.FactQTY = dto.FactQTY;
        row.FactCumulative = dto.FactCumulative;
        row.DowntimeMinutes = dto.DowntimeMinutes;

        await _repository.UpdateAsync(row);

        // 2️⃣ если есть простой — сохраняем отклонение
        if (dto.DowntimeMinutes > 0)
        {
            if (!dto.ReasonGroupId.HasValue ||
                !dto.ReasonId.HasValue ||
                !dto.ResponsibleUserId.HasValue)
            {
                throw new Exception("Downtime requires reason group, reason and responsible user");
            }

            var deviation = new Deviation
            {
                RowId = row.Id,
                Value = dto.DowntimeMinutes,
                ReasonGroupId = dto.ReasonGroupId.Value,
                ReasonId = dto.ReasonId.Value,
                ResponsibleUserId = dto.ResponsibleUserId.Value,
                Comment = dto.Comment,
                TakenMeasures = dto.TakenMeasures
            };

            await _repository.AddDeviationAsync(deviation);
        }
    }
    
    public async Task UpdateRow(UpdateRowDto dto)
    {
        var row = await _repository.GetRowWithDeviation(dto.RowId);
        if (row == null)
            throw new Exception("Row not found");

        // 1️⃣ обновляем факт
        row.FactQTY = dto.FactQTY;
        row.FactCumulative = dto.FactQTY;
        row.DowntimeMinutes = dto.DowntimeMinutes;

        var deviation = row.Deviations.FirstOrDefault();

        // 2️⃣ если простой есть
        if (dto.DowntimeMinutes > 0)
        {
            if (dto.ReasonGroupId <= 0 ||
                dto.ResponsibleUserId <= 0)
            {
                throw new Exception("Invalid downtime data");
            }

            if (deviation == null)
            {
                // ➕ создаём новое отклонение
                deviation = new Deviation
                {
                    RowId = row.Id
                };
                row.Deviations.Add(deviation);
            }

            deviation.Value = dto.DowntimeMinutes;
            deviation.ReasonGroupId = dto.ReasonGroupId.Value;
            deviation.ResponsibleUserId = dto.ResponsibleUserId.Value;
            deviation.Comment = dto.Comment;
            deviation.TakenMeasures = dto.TakenMeasures;
        }
        else
        {
            // 3️⃣ простоя нет — удаляем отклонение
            if (deviation != null)
            {
                _repository.RemoveDeviation(deviation);
            }
        }

        await _repository.Save();
    }
    
    public async Task UpdateRows(List<UpdateRowDto> dtos)
    {
        var factSum = 0;
        foreach (var dto in dtos)
        {
            var row = await _repository.GetRowWithDeviation(dto.RowId);
            if (row == null)
                throw new Exception("Row not found");

            // 1️⃣ обновляем факт
            row.FactQTY = dto.FactQTY;
            row.FactCumulative = factSum + dto.FactQTY;
            factSum += row.FactQTY;
            row.DowntimeMinutes = dto.DowntimeMinutes;

            var deviation = row.Deviations.FirstOrDefault();

            // 2️⃣ если простой есть
            if (dto.DowntimeMinutes > 0)
            {
                if (dto.ReasonGroupId <= 0 ||
                    dto.ResponsibleUserId <= 0)
                {
                    throw new Exception("Invalid downtime data");
                }

                if (deviation == null)
                {
                    // ➕ создаём новое отклонение
                    deviation = new Deviation
                    {
                        RowId = row.Id
                    };
                    row.Deviations.Add(deviation);
                }

                deviation.Value = dto.DowntimeMinutes;
                deviation.ReasonGroupId = dto.ReasonGroupId.Value;
                deviation.ResponsibleUserId = dto.ResponsibleUserId.Value;
                deviation.Comment = dto.Comment;
                deviation.TakenMeasures = dto.TakenMeasures;
            }
            else
            {
                // 3️⃣ простоя нет — удаляем отклонение
                if (deviation != null)
                {
                    _repository.RemoveDeviation(deviation);
                }
            }
        }
        await _repository.Save();
    }
    
    public async Task<List<RowTableDto>> GetTableRows(int productionAnalysisId)
    {
        var rows = await _repository.GetTableRows(productionAnalysisId);

        var result = new List<RowTableDto>();

        foreach (var row in rows)
        {
            var deviation = row.Deviations.FirstOrDefault();

            result.Add(new RowTableDto
            {
                RowId = row.Id,

                PlanQTY = row.PlanQTY,
                PlanCumulative = row.PlanCumulative,

                FactQTY = row.FactQTY,

                DowntimeMinutes = row.DowntimeMinutes,

                DeviationValue = deviation?.Value,

                ReasonGroupId = deviation?.ReasonGroupId,
                ReasonGroupName = deviation?.ReasonGroup?.Name,

                ReasonId = deviation?.ReasonId,
                ReasonDescription = deviation?.Reason?.Description,

                ResponsibleUserId = deviation?.ResponsibleUserId,
                ResponsibleUserName = deviation?.ResponsibleUser?.FirstName,

                Comment = deviation?.Comment,
                TakenMeasures = deviation?.TakenMeasures
            });
        }

        return result;
    }
    
    public async Task<ProductionAnalysisTableDto> GetTable(int shiftId)
    {
        var pa = await _repository.GetAnalysisWithTable(shiftId);

        var rows = new List<ProductionAnalysisRowDto>();

        int cumulativePlan = 0;
        int cumulativeFact = 0;

        foreach (var r in pa.Rows.OrderBy(x => x.WorkIntervalId))
        {
            cumulativePlan += r.PlanQTY;
            cumulativeFact += r.FactQTY;

            var d = r.Deviations.FirstOrDefault();

            rows.Add(new ProductionAnalysisRowDto
            {
                RowId = r.Id,
                WorkInterval = r.WorkInterval.Name,

                PlanQTY = r.PlanQTY,
                PlanCumulative = cumulativePlan,

                FactQTY = r.FactQTY,
                FactCumulative = cumulativeFact,

                Deviation = r.FactQTY - r.PlanQTY,
                DeviationCumulative = cumulativeFact - cumulativePlan,

                DowntimeMinutes = r.DowntimeMinutes,

                ResponsibleUserId = d?.ResponsibleUserId,
                ResponsibleUserName = d?.ResponsibleUser?.FirstName +  " " + d?.ResponsibleUser?.LastName +  " " + d?.ResponsibleUser?.MiddleName,

                ReasonGroupId = d?.ReasonGroupId,
                ReasonGroupName = d?.ReasonGroup?.Name,

                ReasonId = d?.ReasonId,
                ReasonName = d?.Reason?.Description,

                Comment = d?.Comment,
                TakenMeasures = d?.TakenMeasures
            });
        }

        var product = await _repository.GetProduct(pa.Id);

        return new ProductionAnalysisTableDto
        {
            Id = pa.Id,
            ProductName = product.Name,
            DepartmentName = pa.Department.Name,
            FilledBy = pa.Operator.FirstName +  " " + pa.Operator.LastName +  " " + pa.Operator.MiddleName,
            ShiftInfo = pa.Shift.Date.ToShortDateString(),

            PowerPerHour = pa.Parameters[0].PowerPerHour,
            DailyTarget = pa.Parameters[0].DailyTarget,

            Rows = rows
        };
    }
}

