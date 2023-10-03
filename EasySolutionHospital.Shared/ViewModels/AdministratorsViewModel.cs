using System.ComponentModel.DataAnnotations;

namespace EasySolutionHospital.Shared.ViewModels
{
    public class AdministratorsViewModel
    {
        public string? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
