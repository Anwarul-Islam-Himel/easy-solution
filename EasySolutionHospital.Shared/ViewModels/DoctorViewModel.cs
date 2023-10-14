using System.ComponentModel.DataAnnotations;

namespace EasySolutionHospital.Shared.ViewModels
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Specialization { get; set; }
        [Required(ErrorMessage = "Degree is required")]
        public string Degree { get; set; }
        [Required(ErrorMessage = "National Doctor Id is required")]
        public string? NDoctorId { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? PhonenNumber { get; set; }    
        public bool? Approved { get; set; }
        public string? ConsultingTime { get; set; }
        public int? RoomNumber { get; set; }
        public int? FeeAmount { get; set; }
        public string? ImagePath { get; set; }
    }
}
