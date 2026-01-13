namespace ProductionAnalysisBackend.Repositories.Dictionary;

public interface IDictionaryRepository<T>
{
    public Task<T> GetByIdAsync(int id);
    public Task<T> CreateAsync(T entity);
    public Task<T> UpdateAsync(T entity);
    public Task<T> DeleteAsync(int id);
}