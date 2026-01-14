namespace ProductionAnalysisBackend.Services.Dictionary;

public interface IDictionaryService<T, TDto, TCreateDto>
{
    public Task<Result<TDto>> GetDictionaryById(int id);
    public Task<Result<T>> CreateDictionary(TCreateDto item);
    public Task<Result<string>> UpdateDictionary(int id, TCreateDto item);
    public Task DeleteDictionary(int id);
}