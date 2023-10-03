using EasySolutionHospital.Shared.Enum;

namespace EasySolutionHospital.API.Entity
{
    public class Booking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public DateTime AppointTime { get; set; }
        public int DoctorId { get; set; }
    }
}
