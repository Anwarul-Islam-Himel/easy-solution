﻿using AutoMapper;
using EasySolutionHospital.API.Entities;
using EasySolutionHospital.API.Entity;
using EasySolutionHospital.API.Infrastructures;
using EasySolutionHospital.Models;
using EasySolutionHospital.Shared.ResponseModel;
using EasySolutionHospital.Shared.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EasySolutionHospital.API.Services
{
    public interface IHospitalService
    {
        Task<List<TestParameterVM>> GetAllTestParameterAsync();
        Task<List<TestParameterVM>> GetTestParametersByIdAsync(int id);
        Task<Unit> BookingHelthCheckUpAsync(AppointmentModel appointmentForm);
        Task<Unit> ApplyDoctorAsync(DoctorViewModel doctor);
 	    Task<List<AppointmentModel>> GetAllHelthBookingAsync();
        Task<List<AppointmentModel>> GetMyAppointmentById(string id);
        Task<List<AppointmentModel>> GetMyAppointmentByEmail(string email);
        Task<List<DoctorViewModel>> GetApprovedDoctor();
        Task<DoctorViewModel> GetDoctorById(int id);
    }
    public class HospitalService : IHospitalService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public HospitalService(AppDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Unit> BookingHelthCheckUpAsync(AppointmentModel model)
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
                    AppointTime = model.AppointDate,
                    PackageId = model.HealthPackageId.Value
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

        public async Task<List<AppointmentModel>> GetAllHelthBookingAsync()
        {
            try
            {
                var booking = await _context.Bookings
                    .Where(x => x.PackageId != 0)
                    .ToListAsync();
                var packages = await _context.Packages.ToListAsync();

                var returnBookings = new List<AppointmentModel>();

                foreach (var book in booking)
                {
                    var bookPackage = packages.Where(x => x.Id == book.PackageId).FirstOrDefault();
                    if(bookPackage != null)
                    {
                        var response = new AppointmentModel
                        {
                            Id = book.Id,
                            Name = book.Name,
                            Email = book.Email,
                            Description = book.Description,
                            Age = book.Age,
                            AppointDate = book.AppointTime,
                            Phone = book.Phone,
                            Gender = book.Gender,
                            HealthPackageId = bookPackage.Id,
                            HealthPackageName = bookPackage.Name,
                            PriceForMale = bookPackage.PriceForMale,
                            PriceForFemale = bookPackage.PriceForFemale
                        };
                        returnBookings.Add(response);
                    }
                }
                return returnBookings;
            }
            catch(Exception ex)
            {
                return new List<AppointmentModel>();
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

        public async Task<List<AppointmentModel>> GetMyAppointmentById(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                return await GetMyAppointmentByEmail(user.Email);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<AppointmentModel>> GetMyAppointmentByEmail(string email)
        {
            try
            {
                var appoints = await _context.Bookings
                   .Where(x => x.Email == email)
                   .ToListAsync();
                var doctorId = new List<int>();
                foreach (var appointment in appoints)
                {
                    if (appointment.DoctorId != 0)
                    {
                        doctorId.Add(appointment.DoctorId);
                    }
                }
                var doctors = await _context.Doctors.Where(x => doctorId.Contains(x.Id))
                    .Include(x => x.User).ToArrayAsync();

                var returnBookings = new List<AppointmentModel>();

                foreach (var appoint in appoints)
                {
                    var doctorAppoint = doctors.Where(x => x.Id == appoint.DoctorId).FirstOrDefault();
                    if (doctorAppoint != null)
                    {
                        var response = new AppointmentModel
                        {
                            Id = appoint.Id,
                            Name = appoint.Name,
                            Email = appoint.Email,
                            Description = appoint.Description,
                            Age = appoint.Age,
                            AppointDate = appoint.AppointTime,
                            Phone = appoint.Phone,
                            Gender = appoint.Gender,
                            DoctorId = doctorAppoint.Id,
                            DoctorName = doctorAppoint.User.FirstName + doctorAppoint.User.LastName,
                            DoctorSpecialization = doctorAppoint.Specialization
                        };
                        returnBookings.Add(response);
                    }
                }
                return returnBookings;
            }
            catch
            {
                return new List<AppointmentModel>();
            }
        }

        public async Task<List<DoctorViewModel>> GetApprovedDoctor()
        {
            try
            {
                var doctors = await _context.Doctors
                   .Where(x => x.Approved == true)
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
                    Address = x.User.Address,
                    ImagePath = x.ImagePath
                }).ToList();
            }
            catch
            {
                return new List<DoctorViewModel>();
            }
        }

        public async Task<DoctorViewModel> GetDoctorById(int id)
        {
            try
            {
                var doctor = await _context.Doctors
                   .Where(x => x.Approved == true && x.Id == id)
                   .Include(x => x.User)
                   .FirstOrDefaultAsync();

                return new DoctorViewModel
                {
                    Id = doctor.Id,
                    FirstName = doctor.User.FirstName,
                    LastName = doctor.User.LastName,
                    Email = doctor.User.Email,
                    Specialization = doctor.Specialization,
                    Degree = doctor.Degree,
                    FeeAmount = doctor.FeeAmount,
                    RoomNumber = doctor.RoomNumber,
                    ImagePath = doctor.ImagePath,
                    ConsultingTime = doctor.ConsultingTime
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
