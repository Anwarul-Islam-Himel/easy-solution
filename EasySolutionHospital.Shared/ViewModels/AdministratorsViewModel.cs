using System.ComponentModel.DataAnnotations;

namespace EasySolutionHospital.Shared.ViewModels
{
    public class AdministratorsViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
