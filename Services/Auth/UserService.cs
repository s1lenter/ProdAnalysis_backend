using AutoMapper;
using ProductionAnalysisBackend.Dto;
using ProductionAnalysisBackend.Models;
using ProductionAnalysisBackend.Repositories.Dictionary;
using ProductionAnalysisBackend.Services.Dictionary;

namespace ProductionAnalysisBackend.Services;

public class UserService : DictionaryService<User, UserDto, UserCreateDto>
{
    private readonly IMapper _mapper;
    private readonly IDictionaryRepository<User> _repository;
    private readonly IPersonalKeyGenerator _keyGenerator;
    private readonly IPersonalKeyHasher _keyHasher;

    public UserService(AppDbContext dbContext, IMapper mapper, IPersonalKeyGenerator keyGenerator, IPersonalKeyHasher hasher) : base(dbContext, mapper)
    {
        _keyGenerator =  keyGenerator;
        _mapper = mapper;
        _repository = new DictionaryRepository<User>(dbContext);
        _keyHasher = hasher;
    }
    
    public override async Task<Result<User>> CreateDictionary(UserCreateDto item)
    {
        var user =  _mapper.Map<UserCreateDto, User>(item);
        user.CreatedAt = DateTime.UtcNow;
        var key = _keyGenerator.Generate();
        
        // user.PersonalKey = _keyHasher.Hash(key);
        user.PersonalKey = key;
        
        var result = await _repository.CreateAsync(user);
        
        // user.PersonalKey = key;
        
        if (result is null)
            return Result<User>.Failure("Error");
        return Result<User>.Success(result);
    }
}