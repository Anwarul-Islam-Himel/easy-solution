using AutoMapper;
using EasySolutionHospital.API.Entities;
using EasySolutionHospital.API.Entity;
using EasySolutionHospital.API.Infrastructures;
using EasySolutionHospital.Models;
using EasySolutionHospital.Shared.ResponseModel;
using EasySolutionHospital.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EasySolutionHospital.API.Services
{
    public interface IHospitalService
    {
        Task<List<TestParameterVM>> GetAllTestParameterAsync();
        Task<List<TestParameterVM>> GetTestParametersByIdAsync(int id);
        Task<Unit> BookingHelthCheckUpAsync(AppointmentFormModel appointmentForm);
        Task<Unit> ApplyDoctorAsync(DoctorViewModel doctor);
    }
    public class HospitalService : IHospitalService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public HospitalService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> BookingHelthCheckUpAsync(AppointmentFormModel model)
        {
            try
            {
                var newBooking = new Booking
                {
                    Name = model.Name,
                    Email = model.Email,
                    Description = model.Description,
                    Age = model.Age.Value,
                    Phone = model.Phone,
                    Gender = model.Gender,
                    AppointTime = model.AppointDate
                };
                await _context.Bookings.AddAsync(newBooking);
                await _context.SaveChangesAsync();
                return new()
                {
                    IsSuccess = true,
                    Message = "Book health check up successfully!"
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

        public async Task<List<TestParameterVM>> GetAllTestParameterAsync()
        {
            try
            {
                var parameters = await _context.TestParameters.ToListAsync();
                return _mapper.Map<List<TestParameterVM>>(parameters); 
            }
            catch
            {
                return new List<TestParameterVM>();
            }
        }

        public async Task<List<TestParameterVM>> GetTestParametersByIdAsync(int id)
        {
            try
            {
                var parameters = await _context.PackageParameters
                    .Where(p=>p.PackageId == id)
                    .Include(x=>x.TestParameter)
                    .ToListAsync();
                return _mapper.Map<List<TestParameterVM>>(parameters);
            }
            catch
            {
                return new List<TestParameterVM>();
            }
        }

        public async Task<Unit> ApplyDoctorAsync(DoctorViewModel doctor)
        {
            try
            {
                var result = _mapper.Map<Doctor>(doctor);
                await _context.Doctors.AddAsync(result);

                await _context.SaveChangesAsync();
                return new()
                {
                    IsSuccess = true,
                    Message = "Successfully applied!"
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
