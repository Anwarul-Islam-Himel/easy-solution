using EasySolutionHospital.Models;

namespace EasySolutionHospital.Services
{

    public interface IHealthPackageService
    {
        Task<List<HealthPackageVM>> GetAllPackage();
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
    }
}
