using EasySolutionHospital.API.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySolutionHospital.API.EntityConfiguration
{
    public class PackageParameterConfiguration : IEntityTypeConfiguration<PackageParameter>
    {
        public void Configure(EntityTypeBuilder<PackageParameter> builder)
        {
            builder.ToTable(nameof(PackageParameter));
            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.Package)
                .WithMany(x => x.PackageParameters)
                .HasForeignKey(f => f.PackageId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.TestParameter)
                .WithMany(x => x.PackageParameters)
                .HasForeignKey(f => f.TestParameterId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
