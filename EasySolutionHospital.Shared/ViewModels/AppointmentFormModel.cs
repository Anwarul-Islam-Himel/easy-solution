using System.ComponentModel.DataAnnotations;
using EasySolutionHospital.Shared.Enum;

namespace EasySolutionHospital.Models
{
    public class AppointmentFormModel
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime AppointDate { get; set; } = DateTime.Now;
        public string? Description { get; set; }
        public Gender Gender { get; set; }

    }
}
