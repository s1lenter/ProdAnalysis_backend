using ProductionAnalysisBackend.Dto;
using ProductionAnalysisBackend.Models;
using ProductionAnalysisBackend.Services.Dictionary;

namespace ProductionAnalysisBackend.Controllers;

public class DepartmentController : DictionaryController<Department, DepartmentDto, DepartmentCreateDto>
{
    public DepartmentController(IDictionaryService<Department, DepartmentDto, DepartmentCreateDto> dictionaryService) : base(dictionaryService)
    {
    }
}