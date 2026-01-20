using Microsoft.EntityFrameworkCore;
using ProductionAnalysisBackend.Models;

namespace ProductionAnalysisBackend.Repositories.Dictionary;

public class DictionaryRepository<T> : IDictionaryRepository<T>
    where T: class, IDictionaryEntity
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;
    public DictionaryRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<List<T>> GetAllAsync(int page, int pageSize)
    {
        return await _dbSet.Skip((page - 1) * pageSize).Take(pageSize).OrderBy(u => u.Id).ToListAsync();
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

    public async Task<T> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(T dictionary)
    {
        _dbSet.Remove(dictionary);
        await _context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}