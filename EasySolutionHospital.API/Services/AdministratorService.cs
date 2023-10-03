using EasySolutionHospital.API.Entity;
using EasySolutionHospital.Shared.ResponseModel;
using EasySolutionHospital.Shared.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace EasySolutionHospital.API.Services
{
    public interface IAdministratorService
    {
     
    }
    public class AdministratorService : IAdministratorService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AdministratorService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
    }
}
