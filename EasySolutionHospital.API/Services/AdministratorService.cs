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
    public interface IAdministratorService
    {
        Task<List<DoctorViewModel>> GetAllAppliedDoctors();
        Task<Unit> ConfirmDoctorApplication(int doctorId);
        Task<Unit> EditDoctorProfile(DoctorEditFormModel model, int id);
    }
    public class AdministratorService : IAdministratorService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _context;

        public AdministratorService(UserManager<ApplicationUser> userManager, AppDbContext dbContext)
        {
            _userManager = userManager;
            _context = dbContext;
        }

        public async Task<Unit> ConfirmDoctorApplication(int doctorId)
        {
            try
            {
                var doctor = await _context.Doctors.FindAsync(doctorId);
                if(doctor == null)
                {
                    return new()
                    {
                        IsSuccess = false,
                        Message = "Doctor not found!"
                    };
                }
                doctor.Approved = true;
                _context.Doctors.Update(doctor);

                var user = await _userManager.FindByIdAsync(doctor.UserId);

                var passwordHasher = new PasswordHasher<ApplicationUser>();
                string password = "abcd1234";
                user.PasswordHash = passwordHasher.HashPassword(user, password);

                await _userManager.UpdateAsync(user);
                await _context.SaveChangesAsync();
                await _userManager.AddToRoleAsync(user, UserRoleType.Doctor.ToString());

                return new()
                {
                    IsSuccess = true,
                    Message = "Successfully confirm doctor application"
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

        public async Task<List<DoctorViewModel>> GetAllAppliedDoctors()
        {
            try
            {
                var doctors = await _context.Doctors
                    .Where(x => x.Approved == false)
                    .Include(x => x.User)
                    .ToListAsync();

                return doctors.Select(x => new DoctorViewModel
                {
                    Id = x.Id,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    Email = x.User.Email,
                    PhonenNumber = x.User.PhoneNumber,
                    Specialization = x.Specialization,
                    NDoctorId = x.NDoctorId,
                    Degree = x.Degree,
                    DateOfBirth = x.User.DateOfBirth,
                    Address = x.User.Address
                }).ToList();
            }
            catch (Exception ex)
            {
                return new();
            }
        }

        public async Task<Unit> EditDoctorProfile(DoctorEditFormModel model, int id)
        {
            try
            {
                var doctor = await _context.Doctors.FindAsync(id);

                if(doctor == null)
                {
                    return new()
                    {
                        IsSuccess = false,
                        Message = "Doctor not found!!"
                    };
                }
                doctor.ImagePath = model.ImagePath;
                doctor.FeeAmount = model.FeeAmount;
                doctor.RoomNumber = model.RoomNumber;
                doctor.ConsultingTime = model.ConsultingTime;

                _context.Doctors.Update(doctor);
                await _context.SaveChangesAsync();

                return new()
                {
                    IsSuccess = true,
                    Message = "Successfully edit doctor profile"
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
    }
}
