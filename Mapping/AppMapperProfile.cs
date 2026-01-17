using AutoMapper;
using ProductionAnalysisBackend.Dto;
using ProductionAnalysisBackend.Models;

namespace ProductionAnalysisBackend.Mapping;

public class AppMapperProfile : Profile
{
    public AppMapperProfile()
    {
        CreateMap<Product, ProductCreateDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, UserCreateDto>().ReverseMap();
    }
}