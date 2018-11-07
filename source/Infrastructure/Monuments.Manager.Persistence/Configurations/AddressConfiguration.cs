using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monuments.Manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Persistence.Configurations
{
    public class AddressConfiguration : BaseConfiguration<AddressEntity>
    {
        public override void Configure(EntityTypeBuilder<AddressEntity> builder)
        {
            base.Configure(builder);

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
