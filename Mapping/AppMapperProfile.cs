using AutoMapper;
using ProductionAnalysisBackend.Dto;
using ProductionAnalysisBackend.Dto.ReasonGroup;
using ProductionAnalysisBackend.Dto.Supervisor;
using ProductionAnalysisBackend.Dto.Tables;
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
        CreateMap<Shift, ShiftDto>().ReverseMap();
        CreateMap<Shift, ShiftCreateDto>().ReverseMap();
        CreateMap<PowerPerHourTableCreateDto, ProductionAnalysis>().ReverseMap();
        CreateMap<PowerPerHourTableCreateDto, Parameter>().ReverseMap().ForMember("PowerPerHour", opt
            => opt.MapFrom(c => c.PowerPerHour)).ForMember("DailyTarget", opt
            => opt.MapFrom(c => c.DailyTarget));
        CreateMap<Department, DepartmentDto>().ReverseMap();
        CreateMap<Department, DepartmentCreateDto>().ReverseMap();
        CreateMap<ReasonGroup, ReasonGroupDto>().ReverseMap();
        CreateMap<ReasonGroup, ReasonGroupCreateDto>().ReverseMap();
    }
}