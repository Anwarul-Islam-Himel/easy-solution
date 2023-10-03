using EasySolutionHospital.API.Entity;
using EasySolutionHospital.API.Infrastructures;
using EasySolutionHospital.Shared.Enum;
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

        public async  Task<Unit> AddAdministrator(AdministratorsViewModel model)
        {
            try
            {
                var administrator = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    DateOfBirth = model.DateOfBirth,
                    UserName = model.Email,
                    NormalizedUserName = model.Email.ToUpper(),
                    Email = model.Email,
                    NormalizedEmail = model.Email.ToUpper()
                };
                var result = await _userManager.CreateAsync(administrator, AppSettings.Settings.AdministratorPassword);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(administrator, UserRoleType.Administrator.ToString());
                    return new()
                    {
                        IsSuccess = true,
                        Message = "Successfully added administrator!",
                        ResponseId = administrator.Id
                    };
                }

                return new()
                {
                    IsSuccess = false,
                    Message = "Duplicate email or something wrong!"
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public Task<Unit> DeleteAdministrator(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> EditAdministrator(AdministratorsViewModel model, string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AdministratorsViewModel>> GetAllAdministrators()
        {
            try
            {
                var models = await _userManager.GetUsersInRoleAsync(UserRoleType.Administrator.ToString());
                return models.Select(x => new AdministratorsViewModel
                {
                    UserId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Address = x.Address,
                    DateOfBirth = x.DateOfBirth,
                    Email = x.Email,
                    Phone = x.Email
                }).ToList();
            }
            catch (Exception ex)
            {
                return new List<AdministratorsViewModel>();
            }
        }
    }
}
