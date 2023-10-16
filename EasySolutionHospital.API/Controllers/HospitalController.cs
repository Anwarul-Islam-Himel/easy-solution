using EasySolutionHospital.API.Services;
using EasySolutionHospital.Models;
using EasySolutionHospital.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EasySolutionHospital.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalService _hospitalService;
        public HospitalController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        [HttpGet, Route("test-parameters")]
        public async Task<IActionResult> GetAllParameters() 
        {
            var response = await _hospitalService.GetAllTestParameterAsync();
            return Ok(response);
        }

        [HttpGet, Route("package-parameters/{id}")]
        public async Task<IActionResult> GetParametersByPackage(int id)
        {
            var response = await _hospitalService.GetTestParametersByIdAsync(id);
            return Ok(response);
        }

        [HttpPost, Route("book-checkup")]
        public async Task<IActionResult> BookingHealthCheckUp(AppointmentModel model)
        {
            var response = await _hospitalService.BookingHelthCheckUpAsync(model);
            return Ok(response);
        }

        [HttpPost, Route("apply-doctor")]
        public async Task<IActionResult> ApplyDoctor(DoctorViewModel doctor)
        {
            var response = await _hospitalService.ApplyDoctorAsync(doctor);
            return Ok(response);
        }

	    [HttpGet, Route("book-packages")]
        public async Task<IActionResult> GetBookPackage()
        {
            var ressponse = await _hospitalService.GetAllHelthBookingAsync();
            return Ok(ressponse);
        }

        [HttpGet, Route("my-appointment/{userId}")]
        public async Task<IActionResult> GetMyappointment(string userId)
        {
            var ressponse = await _hospitalService.GetMyAppointmentById(userId);
            return Ok(ressponse);
        }

        [HttpGet, Route("search-appointment/{email}")]
        public async Task<IActionResult> SearchAppointment(string email)
        {
            var ressponse = await _hospitalService.GetMyAppointmentByEmail(email);
            return Ok(ressponse);
        }

        [HttpGet, Route("approved-doctor")]
        public async Task<IActionResult> GetApprovedDoctor()
        {
            var response = await _hospitalService.GetApprovedDoctor();
            return Ok(response);
        }

        [HttpGet, Route("doctor-details/{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var response = await _hospitalService.GetDoctorById(id);
            return Ok(response);
        }

        [HttpGet, Route("add-money/{id}/{userId}")]
        public async Task<IActionResult> AddMoney(Guid id, string userId)
        {
            var response = await _hospitalService.AddMoneyInProfile(id, userId);
            return Ok(response);
        }

        [HttpPost, Route("take-appointment")]
        public async Task<IActionResult> TakeAppointMent(AppointmentModel model)
        {
            var response = await _hospitalService.TakeAppointmentAsync(model);
            return Ok(response);
        }

        //[HttpGet, Route("pay-doctor-bill/{bookId}")]
        //public async Task<IActionResult> PayBill(int bookId)
        //{

        //}
    }
}
