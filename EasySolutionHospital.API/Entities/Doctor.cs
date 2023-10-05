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
        public virtual ApplicationUser User { get; set; }
    }
}
