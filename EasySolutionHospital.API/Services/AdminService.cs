using EasySolutionHospital.API.Entity;
using EasySolutionHospital.Shared.ResponseModel;
using EasySolutionHospital.Shared.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace EasySolutionHospital.API.Services
{
    public interface IAdminService
    {
        Task<Unit> AddAdministrator(AdministratorsViewModel model);
        Task<Unit> EditAdministrator(AdministratorsViewModel model, string id);
        Task<Unit> DeleteAdministrator(string id);
        Task<List<AdministratorsViewModel>> GetAllAdministrators();
    }
    public class AdminService : IAdminService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public Task<Unit> AddAdministrator(AdministratorsViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> DeleteAdministrator(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> EditAdministrator(AdministratorsViewModel model, string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AdministratorsViewModel>> GetAllAdministrators()
        {
            throw new NotImplementedException();
        }
    }
}
