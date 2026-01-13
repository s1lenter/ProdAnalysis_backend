using Microsoft.AspNetCore.Mvc;
using ProductionAnalysisBackend.Models;
using ProductionAnalysisBackend.Services.Dictionary;

namespace ProductionAnalysisBackend.Controllers;

[ApiController]
[Route("api/dictionaries/[controller]")]
public class DictionaryController<T, TDto, TCreateDto> : ControllerBase
    where T : class, IDictionaryEntity
    where TDto : class
{
    private readonly IDictionaryService<T, TDto, TCreateDto> _dictionaryService;
    public DictionaryController(IDictionaryService<T, TDto, TCreateDto> dictionaryService)
    {
        _dictionaryService = dictionaryService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDictionary([FromRoute] int id)
    {
        var result = await _dictionaryService.GetDictionaryById(id);
        if (!result.IsSuccess)
            return BadRequest(result.Error);
        return Ok(result.Value);
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateDictionary([FromBody] TCreateDto dto)
    {
        var result = await _dictionaryService.CreateDictionary(dto);
        if (!result.IsSuccess)
            return BadRequest(result.Error);
        return Ok(result.Value);
    }
    
    // [HttpPut("update")]
    // public async Task<IActionResult> UpdateDictionary()
    // {
    //     
    // }
    //
    // [HttpDelete("delete")]
    // public async Task<IActionResult> DeleteDictionary()
    // {
    //     
    // }
}
