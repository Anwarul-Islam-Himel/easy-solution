namespace EasySolutionHospital.Shared.ViewModels
{
    public class DoctorEditFormModel
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public int Id { get; set; }
        public string? ConsultingTime { get; set; }
        public int? RoomNumber { get; set; }
        public int? FeeAmount { get; set; }
        public string? ImagePath { get; set; }
    }
}
