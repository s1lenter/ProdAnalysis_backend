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

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int page)
    {
        var result = await _dictionaryService.GetAll(page);
        if (!result.IsSuccess)
            return BadRequest(result.Error);
        return Ok(result.Value);
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
    
    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateDictionary([FromRoute] int id, [FromBody] TCreateDto dto)
    {
        var result = await _dictionaryService.UpdateDictionary(id, dto);
        if (!result.IsSuccess)
            return BadRequest(result.Error);
        return Ok(result.Value);
    }
    
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteDictionary([FromRoute] int id)
    {
        await _dictionaryService.DeleteDictionary(id);
        return Ok();
    }
}
