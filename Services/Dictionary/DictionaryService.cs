using AutoMapper;
using ProductionAnalysisBackend.Models;
using ProductionAnalysisBackend.Repositories.Dictionary;

namespace ProductionAnalysisBackend.Services.Dictionary;

public class DictionaryService<T, TDto, TCreateDto> : IDictionaryService<T, TDto, TCreateDto>
    where T : class, IDictionaryEntity
{
    private readonly IDictionaryRepository<T> _repository;
    private readonly IMapper _mapper;
    
    private readonly int _pageSize = 10;
    public DictionaryService(AppDbContext dbContext, IMapper mapper)
    {
        _repository = new DictionaryRepository<T>(dbContext);
        _mapper = mapper;
    }

    public async Task<Result<List<TDto>>> GetAll(int page)
    {
        var dictionaries = await _repository.GetAllAsync(page, _pageSize);
        var dictDtos = _mapper.Map<List<TDto>>(dictionaries);
        
        return Result<List<TDto>>.Success(dictDtos);
    }

    public async Task<Result<TDto>> GetDictionaryById(int id)
    {
        var dict = await _repository.GetByIdAsync(id);
        if (dict is null)
            return Result<TDto>.Failure("Error");
        
        var dictDto = _mapper.Map<T, TDto>(dict);
        
        return Result<TDto>.Success(dictDto);
    }

    public virtual async Task<Result<T>> CreateDictionary(TCreateDto item)
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