using Microsoft.EntityFrameworkCore;
using ProductionAnalysisBackend.Models;

namespace ProductionAnalysisBackend.Repositories.Tables;

public class RowRepository : IRowRepository
{
    private readonly AppDbContext _context;

    public RowRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Row?> GetByIdAsync(int id)
    {
        return await _context.Rows
            .Include(r => r.Deviations)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task UpdateAsync(Row row)
    {
        _context.Rows.Update(row);
        await _context.SaveChangesAsync();
    }

    public async Task AddDeviationAsync(Deviation deviation)
    {
        _context.Deviations.Add(deviation);
        await _context.SaveChangesAsync();
    }
    
    public async Task<Row?> GetRowWithDeviation(int rowId)
    {
        return await _context.Rows
            .Include(r => r.Deviations)
            .FirstOrDefaultAsync(r => r.Id == rowId);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }

    public async Task RemoveDeviation(Deviation deviation)
    {
        _context.Deviations.Remove(deviation);
        await _context.SaveChangesAsync();
    }
    
    public async Task<List<Row>> GetTableRows(int productionAnalysisId)
    {
        return await _context.Rows
            .Where(r => r.ProductionAnalysisId == productionAnalysisId)
            .Include(r => r.WorkInterval)
            .Include(r => r.Deviations)
            .ThenInclude(d => d.ReasonGroup)
            .Include(r => r.Deviations)
            .Include(r => r.Deviations)
            .ThenInclude(d => d.ResponsibleUser)
            .OrderBy(r => r.WorkIntervalId)
            .ToListAsync();
    }
    
    public async Task<ProductionAnalysis> GetAnalysisWithTable(int shiftId)
    {
        return await _context.ProductionAnalyses
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
            .FirstAsync(pa => pa.ShiftId == shiftId);
    }

    public async Task<Product> GetProduct(int paId)
    {
        var paProd = await _context.PAProducts.FirstOrDefaultAsync(p => p.ProductionAnalysisId == paId);
        return await _context.Products.FirstOrDefaultAsync(p => paProd.ProductId == p.Id);
    }
}
