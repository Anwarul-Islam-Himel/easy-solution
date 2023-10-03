using EasySolutionHospital.API.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySolutionHospital.API.EntityConfiguration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable(nameof(Booking));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("nvarchar(50)");
            builder.Property(x => x.Description).HasColumnType("nvarchar(500)");
            builder.Property(x => x.Email).HasColumnType("nvarchar(30)");
            builder.Property(x => x.Phone).HasColumnType("nvarchar(30)");
        }
    }
}
