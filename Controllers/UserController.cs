using Microsoft.AspNetCore.Mvc;
using ProductionAnalysisBackend.Dto;
using ProductionAnalysisBackend.Models;
using ProductionAnalysisBackend.Services.Dictionary;

namespace ProductionAnalysisBackend.Controllers;

public class UserController : DictionaryController<User, UserDto, UserCreateDto>
{
    public UserController(IDictionaryService<User, UserDto, UserCreateDto> dictionaryService) : base(dictionaryService) {}

    [HttpGet("/asfasfm")]
    public ActionResult Index()
    {
        return Ok();
    }
}