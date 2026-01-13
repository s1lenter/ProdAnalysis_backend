using ProductionAnalysisBackend.Dto;
using ProductionAnalysisBackend.Models;
using ProductionAnalysisBackend.Services.Dictionary;

namespace ProductionAnalysisBackend.Controllers;

public class ProductController : DictionaryController<Product, ProductDto, ProductCreateDto> 
{
    public ProductController(IDictionaryService<Product, ProductDto, ProductCreateDto> dictionaryService) 
        : base(dictionaryService) { }
}