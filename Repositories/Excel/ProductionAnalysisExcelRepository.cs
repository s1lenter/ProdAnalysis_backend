using Microsoft.EntityFrameworkCore;
using ProductionAnalysisBackend.Dto.Excel;
using ProductionAnalysisBackend.Models;

namespace ProductionAnalysisBackend.Repositories.Excel;

public class ProductionAnalysisExcelRepository : IProductionAnalysisExcelRepository
{
    private readonly AppDbContext _context;

    public ProductionAnalysisExcelRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ProductionAnalysisExcelDto> GetAnalysisForExcel(int analysisId)
    {
        var pa = await _context.ProductionAnalyses
            .Include(pa => pa.Department)
            .Include(pa => pa.Operator)
            .Include(pa => pa.Shift)
            .Include(pa => pa.Parameters)
            .Include(pa => pa.Rows)
            .ThenInclude(r => r.WorkInterval)
            .Include(pa => pa.Rows)
            .ThenInclude(r => r.Deviations)
            .ThenInclude(d => d.ReasonGroup)
            .Include(pa => pa.Rows)
            .ThenInclude(r => r.Deviations)
            .Include(pa => pa.Rows)
            .ThenInclude(r => r.Deviations)
            .ThenInclude(d => d.ResponsibleUser)
            .FirstAsync(pa => pa.Id == analysisId);

        var parameter = pa.Parameters.First();

        var product = await GetProduct(analysisId);

        return new ProductionAnalysisExcelDto
        {
            ProductName = product.Name,
            DepartmentName = pa.Department.Name,
            FilledBy = pa.Operator.LastName + " " + pa.Operator.FirstName + " " + pa.Operator.MiddleName,
            ShiftInfo = pa.CreatedAt.ToString("dd.MM.yyyy"),
            
            PowerPerHour = parameter.PowerPerHour,
            TaktTime = parameter.TaktTimeSec,
            DailyTarget = parameter.DailyTarget,

            Rows = pa.Rows
                .OrderBy(r => r.Id)
                .Select(r =>
                {
                    var d = r.Deviations.FirstOrDefault();

                    return new ProductionAnalysisExcelRowDto
                    {
                        WorkInterval = r.WorkInterval.Name,

                        PlanQTY = r.PlanQTY,
                        PlanCumulative = r.PlanCumulative,

                        FactQTY = r.FactQTY,
                        FactCumulative = r.FactCumulative,

                        Deviation = r.FactQTY - r.PlanQTY,
                        DeviationCumulative = r.FactCumulative - r.PlanCumulative,

                        DowntimeMinutes = r.DowntimeMinutes,

                        ResponsibleUserName = d?.ResponsibleUser?.LastName + " " + d?.ResponsibleUser?.FirstName + " " + d?.ResponsibleUser?.MiddleName ?? "",
                        ReasonGroupName = d?.ReasonGroup?.Name ?? "",
                        Comment = d?.Comment ?? "",
                        TakenMeasures = d?.TakenMeasures ?? ""
                    };
                })
                .ToList()
        };
    }
    
    private async Task<Product> GetProduct(int paId)
    {
        var paProd = await _context.PAProducts.FirstOrDefaultAsync(p => p.ProductionAnalysisId == paId);
        return await _context.Products.FirstOrDefaultAsync(p => paProd.ProductId == p.Id);
    }
}
