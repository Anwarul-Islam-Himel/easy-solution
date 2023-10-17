using EasySolutionHospital.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EasySolutionHospital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetDoctorProfil(string id)
        {
            var response = await _doctorService.GetDoctorProfile(id);
            return Ok(response);
        }

        [HttpGet, Route("appointment/{id}")]
        public async Task<IActionResult> GetDoctorsAppointment(string id)
        {
            var response = await _doctorService.GetDoctorAppointListAsync(id);
            return Ok(response);
        }
    }
}
