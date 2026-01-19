using ProductionAnalysisBackend.Dto.ReasonGroup;
using ProductionAnalysisBackend.Models;
using ProductionAnalysisBackend.Services.Dictionary;

namespace ProductionAnalysisBackend.Controllers;

public class ReasonGroupController : DictionaryController<ReasonGroup, ReasonGroupDto, ReasonGroupCreateDto>
{
    public ReasonGroupController(IDictionaryService<ReasonGroup, ReasonGroupDto, ReasonGroupCreateDto> dictionaryService) : base(dictionaryService)
    {
    }
}