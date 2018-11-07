using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monuments.Manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Persistence.Configurations
{
    public class CityConfiguration : BaseConfiguration<CityEntity>
    {
        public override void Configure(EntityTypeBuilder<CityEntity> builder)
        {
            base.Configure(builder);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(s => s.Commune)
                .WithMany(s => s.Cities)
                .HasForeignKey(s => s.CommuneId)
                .HasConstraintName("FK_City_Commune");
        }
    }
}
