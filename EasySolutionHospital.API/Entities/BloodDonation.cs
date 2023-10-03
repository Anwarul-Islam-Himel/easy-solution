using EasySolutionHospital.Shared.Enum;

namespace EasySolutionHospital.API.Entities
{
    public class BloodDonation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public BloodGroupType BloodGroup { get; set; }
        public int BloodAmount { get; set; }
    }
}
