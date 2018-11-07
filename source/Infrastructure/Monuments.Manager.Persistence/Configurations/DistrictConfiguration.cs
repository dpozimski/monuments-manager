using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monuments.Manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Persistence.Configurations
{
    public class DistrictConfiguration : BaseConfiguration<DistrictEntity>
    {
        public override void Configure(EntityTypeBuilder<DistrictEntity> builder)
        {
            base.Configure(builder);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(s => s.Province)
                .WithMany(s => s.Districts)
                .HasForeignKey(s => s.ProvinceId)
                .HasConstraintName("FK_District_Province");
        }
    }
}
