using System.ComponentModel.DataAnnotations;
using EasySolutionHospital.Shared.Enum;

namespace EasySolutionHospital.Models
{
    public class AppointmentModel
    {
        public int? DoctorId { get; set; }
        public int? HealthPackageId { get; set; }
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime? AppointDate { get; set; } = DateTime.Today;
        public string? Description { get; set; }
        public Gender Gender { get; set; }
        public string? DoctorName { get; set; }
        public string? DoctorSpecialization { get; set; }
        public string? HealthPackageName { get; set; }
        public int? PriceForMale { get; set; }
        public int? PriceForFemale { get; set; }
        public bool IsPay { get; set; } = false;
        public int TotalAmount { get; set; }
    }
}
