using AutoMapper;
using ProductionAnalysisBackend.Dto;
using ProductionAnalysisBackend.Models;

namespace ProductionAnalysisBackend.Mapping;

public class AppMapperProfile : Profile
{
    public AppMapperProfile()
    {
        // CreateMap<RegisterDto, User>().ForMember(user => user.FullName, 
        //     opt => 
        //         opt.MapFrom(src => $"{src.LastName} {src.FirstName} {src.MiddleName}"))
        //     .ForMember(user => user.Username, opt => 
        //         opt.MapFrom(src => src.PersonalKey))
        //     .ForMember(user => user.PersonalKey, opt => 
        //         opt.MapFrom(src => PasswordHasher.GetHash(src.Password)));
        CreateMap<Product, ProductCreateDto>().ReverseMap();
    }
}