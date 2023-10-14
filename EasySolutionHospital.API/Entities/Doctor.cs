using EasySolutionHospital.API.Entity;

namespace EasySolutionHospital.API.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Specialization { get; set; }
        public string Degree { get; set; }
        public string UserId { get; set; }
        public string NDoctorId { get; set; }
        public bool Approved { get; set; }
        public string? ConsultingTime { get; set; }
        public int? RoomNumber { get; set; }
        public int? FeeAmount { get; set; }
        public string? ImagePath { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
