using EasySolutionHospital.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySolutionHospital.API.EntityConfiguration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable(nameof(Doctor));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Specialization).HasColumnType("nvarchar(250)");
            builder.Property(x => x.Degree).HasColumnType("nvarchar(250)");

            builder.HasOne(x => x.User)
                .WithOne(d => d.Doctor)
                .HasForeignKey<Doctor>(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
