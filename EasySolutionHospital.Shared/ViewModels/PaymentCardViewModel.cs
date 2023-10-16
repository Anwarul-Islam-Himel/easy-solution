namespace EasySolutionHospital.Shared.ViewModels
{
    public class PaymentCardViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsUsed { get; set; }
    }
}
