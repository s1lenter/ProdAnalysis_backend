using Microsoft.EntityFrameworkCore;
using ProductionAnalysisBackend.Models;

namespace ProductionAnalysisBackend.Repositories.CycleTables;

public class ProductionCycleRepository : IProductionCycleRepository
{
    private readonly AppDbContext _context;

    public ProductionCycleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAnalysis(ProductionCycleAnalysis analysis)
    {
        await _context.AddAsync(analysis);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ProductExists(int productId)
    {
        return await _context.Products.AnyAsync(p => p.Id == productId);
    }

    public async Task<bool> DepartmentExists(int departmentId)
    {
        return await _context.Departments.AnyAsync(d => d.Id == departmentId);
    }

    public async Task<bool> UserExists(int userId)
    {
        return await _context.Users.AnyAsync(u => u.Id == userId);
    }
    
    public async Task<ProductionCycleAnalysis?> GetAnalysis(int id)
    {
        return await _context.ProductionCycleAnalyses
            .Include(a => a.Product)
            .Include(a => a.Department)
            .Include(a => a.Operator)
            .Include(a => a.Operations)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<CycleOperation?> GetOperation(int operationId)
    {
        return await _context.CycleOperations
            .FirstOrDefaultAsync(o => o.Id == operationId);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}