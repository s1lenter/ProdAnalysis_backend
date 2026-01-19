using AutoMapper;
using ProductionAnalysisBackend.Dto.ReasonGroup;
using ProductionAnalysisBackend.Services.Dictionary;
using ProductionAnalysisBackend.Models;

namespace ProductionAnalysisBackend.Services.Reason;

public class ReasonService : DictionaryService<Models.Reason, ReasonDto, ReasonGroupCreateDto>
{
    public ReasonService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
}