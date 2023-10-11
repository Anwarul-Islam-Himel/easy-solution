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
        public string NDoctorId { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
