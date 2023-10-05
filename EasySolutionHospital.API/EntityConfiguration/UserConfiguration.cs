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
            builder.Property(x => x.FirstName).IsRequired(false).HasColumnType("nvarchar(50)");
            builder.Property(x => x.LastName).IsRequired(false).HasColumnType("nvarchar(50)");
            builder.Property(x => x.Address).IsRequired(false).HasColumnType("nvarchar(100)");
        }
    }
}
