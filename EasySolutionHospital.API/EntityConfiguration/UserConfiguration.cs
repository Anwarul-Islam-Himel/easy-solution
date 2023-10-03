using EasySolutionHospital.API.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySolutionHospital.API.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasColumnType("nvarchar(50)");
            builder.Property(x => x.LastName).HasColumnType("nvarchar(50)");
            builder.Property(x => x.Address).HasColumnType("nvarchar(100)");
        }
    }
}
