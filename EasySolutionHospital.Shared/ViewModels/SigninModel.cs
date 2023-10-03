using System.ComponentModel.DataAnnotations;

namespace EasySolutionHospital.Models
{
    public class SigninModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
