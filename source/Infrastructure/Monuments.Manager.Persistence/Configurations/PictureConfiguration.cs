using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monuments.Manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Persistence.Configurations
{
    public class PictureConfiguration : BaseConfiguration<PictureEntity>
    {
        public override void Configure(EntityTypeBuilder<PictureEntity> builder)
        {
            base.Configure(builder);

            builder.HasOne(s => s.Monument)
                .WithMany(s => s.Pictures)
                .HasForeignKey(s => s.MonumentId)
                .HasConstraintName("FK_Picture_Monument");

            builder.Property(s => s.Small)
                .IsRequired()
                .HasMaxLength(int.MaxValue);

            builder.Property(s => s.Medium)
                .IsRequired()
                .HasMaxLength(int.MaxValue);

            builder.Property(s => s.Original)
                .IsRequired()
                .HasMaxLength(int.MaxValue);

            builder.Property(s => s.Description)
                .HasMaxLength(1000);
        }
    }
}
