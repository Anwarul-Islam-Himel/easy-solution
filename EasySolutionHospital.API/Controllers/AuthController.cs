using EasySolutionHospital.API.Services;
using EasySolutionHospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasySolutionHospital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost, Route("signup")]
        public async Task<IActionResult> AddUser(RegisterModel model)
        {
            var response = await _authService.SignUp(model);
            if(response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpPost, Route("signin")]
        public async Task<IActionResult> Login(SigninModel model)
        {
            var response = await _authService.SignIn(model);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpGet, Route("currentUser/{userId}")]
        public async Task<IActionResult> GetCurrentUser(string userId)
        {
            var response = await _authService.GetLoggedUserInformation(userId);
            return Ok(response);
        }
    }
}
