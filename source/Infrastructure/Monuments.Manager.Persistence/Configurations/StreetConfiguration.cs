using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monuments.Manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Persistence.Configurations
{
    public class StreetConfiguration : BaseConfiguration<StreetEntity>
    {
        public override void Configure(EntityTypeBuilder<StreetEntity> builder)
        {
            base.Configure(builder);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(s => s.City)
                .WithMany(s => s.Streets)
                .HasForeignKey(s => s.CityId)
                .HasConstraintName("FK_Street_City");
        }
    }
}
