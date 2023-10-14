using EasySolutionHospital.API.Services;
using EasySolutionHospital.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EasySolutionHospital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly IAdministratorService _administratorService;
        public AdministratorController(IAdministratorService administratorService)
        {
            _administratorService = administratorService;
        }

        [HttpGet, Route("doctors")]
        public async Task<IActionResult> GetDoctors()
        {
            var response = await _administratorService.GetAllAppliedDoctors();
            return Ok(response);
        }

        [HttpGet, Route("doctor-approved/{id}")]
        public async Task<IActionResult> ApprovedDoctor(int id)
        {
            var response = await _administratorService.ConfirmDoctorApplication(id);
            return Ok(response);
        }

        [HttpPost, Route("edit-doctor/{id}")]
        public async Task<IActionResult> EditDoctor(DoctorEditFormModel model, int id)
        {
            var response = await _administratorService.EditDoctorProfile(model, id);
            return Ok(response);
        }
    }
}
