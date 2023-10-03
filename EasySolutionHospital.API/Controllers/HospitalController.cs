using EasySolutionHospital.API.Services;
using EasySolutionHospital.Models;
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
        public async Task<IActionResult> BookingHealthCheckUp(AppointmentFormModel model)
        {
            var response = await _hospitalService.BookingHelthCheckUpAsync(model);
            return Ok(response);
        }
    }
}
