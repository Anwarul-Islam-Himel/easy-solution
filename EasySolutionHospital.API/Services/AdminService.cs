using EasySolutionHospital.API.Entities;
using EasySolutionHospital.API.Entity;
using EasySolutionHospital.API.Infrastructures;
using EasySolutionHospital.Shared.Enum;
using EasySolutionHospital.Shared.ResponseModel;
using EasySolutionHospital.Shared.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EasySolutionHospital.API.Services
{
    public interface IAdminService
    {
        Task<Unit> AddAdministrator(AdministratorsViewModel model);
        Task<Unit> EditAdministrator(AdministratorsViewModel model, string id);
        Task<Unit> DeleteAdministrator(string id);
        Task<Unit> CreatePaymentCard(PaymentCardViewModel model);
        Task<List<AdministratorsViewModel>> GetAllAdministrators();
        Task<List<PaymentCardViewModel>> GetAllPaymentCards();
    }
    public class AdminService : IAdminService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _context;

        public AdminService(UserManager<ApplicationUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
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

        public async Task<Unit> CreatePaymentCard(PaymentCardViewModel model)
        {
            try
            {
                var newCard = new PaymentCard
                {
                    IsUsed = false,
                    Name = model.Name,
                    Price = model.Price,
                };

                await _context.PaymentCards.AddAsync(newCard);
                await _context.SaveChangesAsync();

                return new()
                {
                    IsSuccess = true,
                    ResponseId = newCard.Id.ToString(),
                    Message = "Successfully create payment card"
                };
            }
            catch(Exception ex)
            {
                return new()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<List<PaymentCardViewModel>> GetAllPaymentCards()
        {
            try
            {
                var cards = await _context.PaymentCards.ToListAsync();

                return cards.Select(x => new PaymentCardViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    IsUsed = x.IsUsed
                }).ToList();
            }
            catch(Exception ex)
            {
                return new List<PaymentCardViewModel>();
            }
        }
    }
}
