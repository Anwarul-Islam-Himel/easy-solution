using EasySolutionHospital.API.Entity;
using EasySolutionHospital.Models;
using EasySolutionHospital.Shared.Enum;
using EasySolutionHospital.Shared.ResponseModel;
using Microsoft.AspNetCore.Identity;
namespace EasySolutionHospital.API.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> SignIn(SigninModel model);
        Task<LoginResponse> SignUp(RegisterModel model);
    }
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AuthService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<LoginResponse> SignUp(RegisterModel model)
        {
            try
            {
                var user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    DateOfBirth = model.DateOfBirth.Value,
                    UserName = model.Email,
                    NormalizedUserName = model.Email.ToUpper(),
                    Email = model.Email,
                    NormalizedEmail = model.Email.ToUpper()
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, UserRoleType.User.ToString());
                }

                return new()
                {
                    Id = user.Id,
                    UserName = model.FirstName + " " + model.LastName,
                    UserRole = UserRoleType.User
                };

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<LoginResponse> SignIn(SigninModel model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var useRole = await _userManager.GetRolesAsync(user);

                    return new()
                    {
                        Id = user.Id,
                        UserName = user.FirstName + " " + user.LastName,
                        UserRole = Enum.Parse<UserRoleType>(useRole.FirstOrDefault())
                    };
                }
                return null;
               
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
