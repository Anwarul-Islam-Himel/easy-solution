﻿using System.ComponentModel.DataAnnotations;

namespace EasySolutionHospital.Models
{
    public class RegisterModel
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? ConfirmPassword { get;set; }
    }
}
