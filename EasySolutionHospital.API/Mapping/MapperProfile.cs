using AutoMapper;
using EasySolutionHospital.API.Entities;
using EasySolutionHospital.API.Entity;
using EasySolutionHospital.Models;
using EasySolutionHospital.Shared.ViewModels;

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

            CreateMap<DoctorViewModel, Doctor>()
                .ForPath(dest => dest.User.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForPath(dest => dest.User.FirstName, opt => opt.MapFrom(src => src.LastName))
                .ForPath(dest => dest.User.Address, opt => opt.MapFrom(src => src.Address))
                .ForPath(dest => dest.User.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth));
        }
    }
}
