﻿using EasySolutionHospital.API.Services;
using EasySolutionHospital.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EasySolutionHospital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController :ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAdministrator()
        {
            var response = await _adminService.GetAllAdministrators();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddAdministrator(AdministratorsViewModel model)
        {
            var response = await _adminService.AddAdministrator(model);
            return Ok(response);
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> UpdateAdministrator(AdministratorsViewModel model, string id)
        {
            var response = await _adminService.EditAdministrator(model, id);
            return Ok(response);
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> DeleteAdministrator( string id)
        {
            var response = await _adminService.DeleteAdministrator(id);
            return Ok(response);
        }
    }
}