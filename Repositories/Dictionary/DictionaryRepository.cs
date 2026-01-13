using Microsoft.EntityFrameworkCore;

namespace ProductionAnalysisBackend.Repositories.Dictionary;

public class DictionaryRepository<T> : IDictionaryRepository<T>
    where T: class
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;
    public DictionaryRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T> CreateAsync(T entity)
    {
        var result = await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public Task<T> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}