using EasySolutionHospital.API.Entity;
using EasySolutionHospital.API.Infrastructures;
using EasySolutionHospital.Models;
using EasySolutionHospital.Shared.Enum;
using EasySolutionHospital.Shared.ResponseModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace EasySolutionHospital.API.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> SignIn(SigninModel model);
        Task<LoginResponse> SignUp(RegisterModel model);
        Task<AppointmentModel> GetLoggedUserInformation(string userId);
    }
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _context;
        public AuthService(UserManager<ApplicationUser> userManager, AppDbContext dbContext)
        {
            _userManager = userManager;
            _context = dbContext;
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
                    UserRole = UserRoleType.User,
                    TotalPurchases = user.TotalPurchase
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

                    if(useRole.FirstOrDefault() == UserRoleType.Doctor.ToString())
                    {
                        var doctor = await _context.Doctors
                            .Where(x => x.UserId == user.Id).FirstOrDefaultAsync();
                        if (!doctor.Approved)
                        {
                            return null;
                        }
                    }

                    return new()
                    {
                        Id = user.Id,
                        UserName = user.FirstName + " " + user.LastName,
                        UserRole = Enum.Parse<UserRoleType>(useRole.FirstOrDefault()),
                        TotalPurchases = user.TotalPurchase
                    };
                }
                return null;
               
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<AppointmentModel> GetLoggedUserInformation(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if(user != null)
                {
                    return new()
                    {
                        Name = user.FirstName + user.LastName,
                        Age = DateTime.Today.Year - user.DateOfBirth.Year,
                        Phone = user.PhoneNumber,
                        Email = user.Email
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
