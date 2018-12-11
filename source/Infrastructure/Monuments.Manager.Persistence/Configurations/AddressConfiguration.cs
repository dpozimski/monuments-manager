using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monuments.Manager.Domain.Entities;

namespace Monuments.Manager.Persistence.Configurations
{
    public class AddressConfiguration : BaseConfiguration<AddressEntity>
    {
        public override void Configure(EntityTypeBuilder<AddressEntity> builder)
        {
            base.Configure(builder);

            builder.HasIndex(s => s.Province).HasName("IX_AddressEntity_Province");
            builder.HasIndex(s => s.District).HasName("IX_AddressEntity_District");
            builder.HasIndex(s => s.Commune).HasName("IX_AddressEntity_Commune");
            builder.HasIndex(s => s.City).HasName("IX_AddressEntity_City");
            builder.HasIndex(s => s.Street).HasName("IX_AddressEntity_Street");
            builder.HasIndex(s => s.StreetNumber).HasName("IX_AddressEntity_StreetNumber");
            builder.HasIndex(s => s.Area).HasName("IX_AddressEntity_Area");

            builder.Property(s => s.Province).HasMaxLength(100);
            builder.Property(s => s.District).HasMaxLength(100);
            builder.Property(s => s.Commune).HasMaxLength(100);
            builder.Property(s => s.City).HasMaxLength(100);
            builder.Property(s => s.Street).HasMaxLength(100);
            builder.Property(s => s.StreetNumber).HasMaxLength(100);
            builder.Property(s => s.Area).HasMaxLength(300);
        }
    }
}
