using AutoMapper;
using ProductionAnalysisBackend.Repositories.Dictionary;

namespace ProductionAnalysisBackend.Services.Dictionary;

public class DictionaryService<T, TDto, TCreateDto> : IDictionaryService<T, TDto, TCreateDto>
    where T : class
{
    private readonly IDictionaryRepository<T> _repository;
    private readonly IMapper _mapper;
    public DictionaryService(AppDbContext dbContext, IMapper mapper)
    {
        _repository = new DictionaryRepository<T>(dbContext);
        _mapper = mapper;
    }
    
    public async Task<Result<TDto>> GetDictionaryById(int id)
    {
        var dict = await _repository.GetByIdAsync(id);
        var dictDto = _mapper.Map<TDto>(dict);
        
        if (dict is null)
            return Result<TDto>.Failure("Error");
        return Result<TDto>.Success(dictDto);
    }

    public async Task<Result<T>> CreateDictionary(TCreateDto item)
    {
        var dict =  _mapper.Map<TCreateDto, T>(item);
        var result = await _repository.CreateAsync(dict);
        
        if (result is null)
            return Result<T>.Failure("Error");
        return Result<T>.Success(result);
    }

    public async Task<Result<string>> UpdateDictionary(int id, TCreateDto item)
    {
        var dict = await _repository.GetByIdAsync(id);
        _mapper.Map(item, dict);
        
        await _repository.SaveChangesAsync();
        return Result<string>.Success("123");
    }

    public async Task DeleteDictionary(int id)
    {
        var dictionary = await _repository.GetByIdAsync(id);
        await _repository.DeleteAsync(dictionary);
    }
}