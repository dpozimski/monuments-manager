using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monuments.Manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Persistence.Configurations
{
    public class CommuneConfiguration : BaseConfiguration<CommuneEntity>
    {
        public override void Configure(EntityTypeBuilder<CommuneEntity> builder)
        {
            base.Configure(builder);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(s => s.District)
                .WithMany(s => s.Communes)
                .HasForeignKey(s => s.DistrictId)
                .HasConstraintName("FK_Commune_District");
        }
    }
}
