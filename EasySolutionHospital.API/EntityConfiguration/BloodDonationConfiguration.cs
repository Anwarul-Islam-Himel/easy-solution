using EasySolutionHospital.API.Entities;
using EasySolutionHospital.API.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySolutionHospital.API.EntityConfiguration
{
    public class BloodDonationConfiguration : IEntityTypeConfiguration<BloodDonation>
    {
        public void Configure(EntityTypeBuilder<BloodDonation> builder)
        {
            builder.ToTable(nameof(BloodDonation));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("nvarchar(50)");
            builder.Property(x => x.Description).HasColumnType("nvarchar(500)");
            builder.Property(x => x.Email).HasColumnType("nvarchar(30)");
            builder.Property(x => x.Phone).HasColumnType("nvarchar(30)");
        }
    }
}
