using EasySolutionHospital.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySolutionHospital.API.EntityConfiguration
{
    public class PaymentCardConfiguration : IEntityTypeConfiguration<PaymentCard>
    {
        public void Configure(EntityTypeBuilder<PaymentCard> builder)
        {
            builder.ToTable(nameof(PaymentCard));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("uniqueidentifier");
            builder.Property(x => x.Name).HasColumnType("navrchar(50)");
        }
    }
}
