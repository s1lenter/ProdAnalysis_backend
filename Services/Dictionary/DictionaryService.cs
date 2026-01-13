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

    public Task<Result<string>> UpdateDictionary(TCreateDto item)
    {
        throw new NotImplementedException();
    }

    public Task DeleteDictionary(int id)
    {
        throw new NotImplementedException();
    }
}