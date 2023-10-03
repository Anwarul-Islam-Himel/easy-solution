namespace EasySolutionHospital.API.Entity
{
    public class PackageParameter
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public virtual Package Package { get; set; }
        public int TestParameterId { get; set; }
        public virtual TestParameter TestParameter { get; set; }
    }
}
