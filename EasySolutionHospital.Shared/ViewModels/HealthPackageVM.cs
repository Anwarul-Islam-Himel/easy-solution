namespace EasySolutionHospital.Models
{
    public class HealthPackageVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PriceForMale { get; set; }
        public int PriceForFemale { get; set; }
        public int Parameters { get; set; }
        public string ImagePath { get; set; }
        public List<TestParameterVM> ParametersList { get; set; }
    }
}
