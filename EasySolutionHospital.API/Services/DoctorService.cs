using EasySolutionHospital.API.Entity;
using EasySolutionHospital.API.Infrastructures;
using EasySolutionHospital.Models;
using EasySolutionHospital.Shared.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EasySolutionHospital.API.Services
{
    public interface IDoctorService
    {
        Task<List<AppointmentModel>> GetDoctorAppointListAsync(string id);
        Task<DoctorViewModel> GetDoctorProfile(string id);
    }
    public class DoctorService : IDoctorService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _context;

        public DoctorService(UserManager<ApplicationUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<List<AppointmentModel>> GetDoctorAppointListAsync(string id)
        {
            try
            {
                var doctor = await _context.Doctors.Where(x => x.UserId == id).FirstOrDefaultAsync();

                var bookings = await _context.Bookings.Where(x => x.DoctorId == doctor.Id).ToListAsync();

                return bookings.Select(x => new AppointmentModel
                {
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                    Age = x.Age,
                    AppointDate = x.AppointTime,
                    Gender = x.Gender,
                    IsPay = x.IsPay != null ? x.IsPay.Value : false
                    
                }).ToList();
            }
            catch
            {
                return new List<AppointmentModel>();
            }
        }

        public async Task<DoctorViewModel> GetDoctorProfile(string id)
        {
            try
            {
                var doctor = await _context.Doctors.Where(x => x.UserId == id).FirstOrDefaultAsync();

                return new DoctorViewModel
                {
                    TotalEarnings = doctor.TotalReceive
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
