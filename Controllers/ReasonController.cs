using ProductionAnalysisBackend.Dto.ReasonGroup;
using ProductionAnalysisBackend.Models;
using ProductionAnalysisBackend.Services.Dictionary;

namespace ProductionAnalysisBackend.Controllers;

public class ReasonController : DictionaryController<Reason, ReasonDto, ReasonCreateDto>
{
    public ReasonController(IDictionaryService<Reason, ReasonDto, ReasonCreateDto> dictionaryService) : base(dictionaryService)
    {
    }
}