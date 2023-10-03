using EasySolutionHospital.API.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySolutionHospital.API.EntityConfiguration
{
    public class TestParameterConfiguration : IEntityTypeConfiguration<TestParameter>
    {
        public void Configure(EntityTypeBuilder<TestParameter> builder)
        {
            builder.ToTable(nameof(TestParameter));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("nvarchar(50)");
        }
    }
}
