using EasySolutionHospital.API.Entities;
using EasySolutionHospital.API.Entity;
using EasySolutionHospital.API.EntityConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasySolutionHospital.API.Infrastructures
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TestParameterConfiguration());
            builder.ApplyConfiguration(new PackageConfiguration());
            builder.ApplyConfiguration(new PackageParameterConfiguration());
            builder.ApplyConfiguration(new BookingConfiguration());
            builder.ApplyConfiguration(new DoctorConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new BloodDonationConfiguration());
            builder.ApplyConfiguration(new PaymentCardConfiguration());
            base.OnModelCreating(builder);
        }

        public DbSet<TestParameter> TestParameters { get; set; }
        public DbSet<PackageParameter> PackageParameters { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<BloodDonation> BloodDonations { get; set; }
        public DbSet<PaymentCard> PaymentCards { get; set; }
    }
}
