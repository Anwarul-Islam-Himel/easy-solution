namespace EasySolutionHospital.API.Entity
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PackageParameter> PackageParameters { get; set; }
    }
}
