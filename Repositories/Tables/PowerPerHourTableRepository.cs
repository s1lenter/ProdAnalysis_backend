using Microsoft.EntityFrameworkCore;
using ProductionAnalysisBackend.Models;

namespace ProductionAnalysisBackend.Repositories.Tables;

public class PowerPerHourTableRepository : IPowerPerHourTableRepository
{
    private readonly AppDbContext _context;

    public PowerPerHourTableRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateProductionAnalysis(ProductionAnalysis productionAnalysis, int productId)
    {
        await _context.ProductionAnalyses.AddAsync(productionAnalysis);
        
        await _context.SaveChangesAsync();
    }

    public async Task CreatePaProducts(int paId, int productId)
    {
        var paProd = new PAProduct
        {
            ProductId = productId,
            ProductionAnalysisId = paId,
        };
        await _context.PAProducts.AddAsync(paProd);
        await _context.SaveChangesAsync();
    }

    public async Task CreatePowerPerHour(Parameter parameter)
    {
        await _context.Parameters.AddAsync(parameter);
        await _context.SaveChangesAsync();
    }

    public async Task CreateRows(int id, int productId, int plan)
    {
        var planSum = 0;
        for (int i = 0; i < 8; i++)
        {
            planSum += plan;
            var row = new Row()
            {
                ProductionAnalysisId = id,
                ProductId = productId,
                WorkIntervalId = 1,
                PlanQTY = plan,
                PlanCumulative = planSum
            };
            await _context.Rows.AddAsync(row);
        }
        await _context.SaveChangesAsync();
    }

    public async Task<Scenario> CreateScenario(string scenario)
    {
        var s = new Scenario()
        {
            Name = scenario,
            Description = "",
            Code = Guid.NewGuid().ToString(),
        };
        await _context.Scenarios.AddAsync(s);
        await _context.SaveChangesAsync();
        return s;
    }
    
    public async Task<List<Row>> GetProductRows(
        int productionAnalysisId,
        int productId)
    {
        return await _context.Rows
            .Where(r =>
                r.ProductionAnalysisId == productionAnalysisId &&
                r.ProductId == productId)
            .Include(r => r.WorkInterval)
            .Include(r => r.Deviations)
            .ThenInclude(d => d.ReasonGroup)
            .Include(r => r.Deviations)
            .Include(r => r.Deviations)
            .ThenInclude(d => d.ResponsibleUser)
            .OrderBy(r => r.WorkIntervalId)
            .ToListAsync();
    }

    public async Task<Product> GetProduct(int productId)
    {
        return await _context.Products.FirstAsync(p => p.Id == productId);
    }

    public async Task<List<ProductionAnalysis>> GetAnalysisForUser(int userId)
    {
        return await _context.ProductionAnalyses.Where(pa => pa.OperatorId == userId).ToListAsync();
    }
    
    public async Task<List<ProductionAnalysis>> GetAnalysisForSupervisor(int userId)
    {
        return await _context.ProductionAnalyses.Where(pa => pa.CreatorId == userId).ToListAsync();
    }

    public async Task<Scenario> GetScenario(int scenarioId)
    {
        return await _context.Scenarios.FirstOrDefaultAsync(s => s.Id == scenarioId);
    }
}