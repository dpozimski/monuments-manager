using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monuments.Manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Persistence.Configurations
{
    public class ProvinceConfiguration : BaseConfiguration<ProvinceEntity>
    {
        public override void Configure(EntityTypeBuilder<ProvinceEntity> builder)
        {
            base.Configure(builder);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
