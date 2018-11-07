using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monuments.Manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Persistence.Configurations
{
    public class MonumentConfiguration : BaseConfiguration<MonumentEntity>
    {
        public override void Configure(EntityTypeBuilder<MonumentEntity> builder)
        {
            base.Configure(builder);

            builder.HasOne(s => s.User)
                .WithMany(s => s.Monuments)
                .HasForeignKey(s => s.UserId)
                .HasConstraintName("FK_Monument_User");

            builder.HasOne(s => s.Address)
                .WithOne(s => s.Monument)
                .HasForeignKey<AddressEntity>()
                .HasConstraintName("FK_Monument_Address");

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.FormOfProtection)
                .HasMaxLength(300);
        }
    }
}
