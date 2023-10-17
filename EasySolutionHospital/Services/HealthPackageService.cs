using EasySolutionHospital.Models;
using EasySolutionHospital.Shared.ViewModels;

namespace EasySolutionHospital.Services
{

    public interface IHealthPackageService
    {
        Task<List<HealthPackageVM>> GetAllPackage();
        Task<List<ServiceViewModel>> GetSuperSpecialityServices();
        Task<List<ServiceViewModel>> GetBroadSpecialityServices();
    }
    public class HealthPackageService : IHealthPackageService
    {
        public Task<List<HealthPackageVM>> GetAllPackage()
        {
            return Task.FromResult(new List<HealthPackageVM>()
            {
                new()
                {
                    Id = 1,
                    Name = "Platinum",
                    Description = "A screening package which covers vital tests like CBC, Blood Sugar, Urine,...",
                    PriceForFemale = 12000,
                    PriceForMale = 11500,
                    ImagePath = "Images/platinum.jpg",
                    Parameters = 50
                },
                new()
                {
                    Id = 2,
                    Name = "Comprehensive Plus",
                    Description = "A screening package which covers vital tests like Blood Sugar, Dental consultation,...",
                    PriceForFemale = 6500,
                    PriceForMale = 6500,
                    ImagePath = "Images/comprehensiveplus.jpg",
                    Parameters = 40
                },
                new()
                {
                    Id = 3,
                    Name = "Comprehensive",
                    Description = "A screening package which covers vital tests like CBC, Blood Sugar, Physical examination,...",
                    PriceForFemale = 5500,
                    PriceForMale = 5500,
                    ImagePath = "Images/comprehensive.jpg",
                    Parameters = 35
                },
                new()
                {
                    Id = 4,
                    Name = "Cancer Check",
                    Description = "A screening package which covers vital tests like CBC, ECG, Audiogram, Urine,...",
                    PriceForFemale = 6000,
                    PriceForMale = 6500,
                    ImagePath = "Images/cancercheck.jpg",
                    Parameters = 30
                },
                new()
                {
                    Id = 5,
                    Name = "Standard",
                    Description = "A standard package which covers all necessary tests like blood, CBC, Gynaecologist consultation,...",
                    PriceForFemale = 2750,
                    PriceForMale = 2750,
                    ImagePath = "Images/standard.jpg",
                    Parameters = 20
                },
                new()
                {
                    Id = 6,
                    Name = "Basic",
                    Description = "A basic package which covers all the necessary tests...",
                    PriceForFemale = 1200,
                    PriceForMale = 1200,
                    ImagePath = "Images/basic.jpg",
                    Parameters = 10
                }
            });
        }

        public Task<List<ServiceViewModel>> GetSuperSpecialityServices()
        {
            return Task.FromResult(new List<ServiceViewModel>()
            {
                new()
                {
                    Name = "Cardiology"
                },
                new()
                {
                    Name = "Cardiovascular Thoracic Surgery"
                },
                new()
                {
                    Name = "Endocrinology"
                },
                new()
                {
                    Name = "Gastroentrology"
                },
                new()
                {
                    Name = "Nephrology"
                },
                new()
                {
                    Name = "Neurology"
                },
                 new()
                {
                    Name = "Neurosurgery"
                },
                new()
                {
                    Name = "Paediatric Surgery"
                },
                new()
                {
                    Name = "Plastic Surgery"
                },
                new()
                {
                    Name = "Pulmonary Medicine"
                },
                new()
                {
                    Name = "Rheumatology"
                },
                new()
                {
                    Name = "Urology"
                },
                new()
                {
                    Name = "Medical Oncology"
                },
                new()
                {
                    Name = "Surgical Oncology"
                },
                new()
                {
                    Name = "Haemato-Oncology"
                },
                new()
                {
                    Name = "Paediatric-Oncology"
                },
                new()
                {
                    Name = "Radiation Oncology"
                }
            });
        }

        public Task<List<ServiceViewModel>> GetBroadSpecialityServices()
        {
            return Task.FromResult(new List<ServiceViewModel>()
            {
                new()
                {
                    Name = "Critical Care Medicine"
                },
                new()
                {
                    Name = "Dermatology"
                },
                new()
                {
                    Name = "Diabetology"
                },
                new()
                {
                    Name = "ENT & Laryngology"
                },
                new()
                {
                    Name = "General Medicine & Infectious"
                },
                new()
                {
                    Name = "General Surgery"
                },
                 new()
                {
                    Name = "Gynaecology & Obstetrics"
                },
                new()
                {
                    Name = "Ophthamalogy"
                },
                new()
                {
                    Name = "Orthopaedics"
                },
                new()
                {
                    Name = "Paediatrics"
                },
                new()
                {
                    Name = "Pyschiatry"
                },
                new()
                {
                    Name = "Spine Surgery"
                }
            });
        }
    }
}
