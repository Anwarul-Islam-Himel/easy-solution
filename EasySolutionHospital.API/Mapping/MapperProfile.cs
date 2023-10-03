using AutoMapper;
using EasySolutionHospital.API.Entity;
using EasySolutionHospital.Models;

namespace EasySolutionHospital.API.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TestParameter, TestParameterVM>();
            CreateMap<PackageParameter, TestParameterVM>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TestParameterId))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TestParameter.Name));
        }
    }
}
