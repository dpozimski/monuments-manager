using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monuments.Manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Persistence.Configurations
{
    public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(s => s.Id);

            builder
                .HasIndex(s => s.CreatedBy)
                .HasName($"IX_{typeof(TEntity).Name}_CreatedBy");

            builder
                .HasIndex(s => s.ModifiedBy)
                .HasName($"IX_{typeof(TEntity).Name}_ModifiedBy");

            builder.Property(s => s.CreatedBy)
                .HasMaxLength(200);
            builder.Property(s => s.ModifiedBy)
                .HasMaxLength(200);
        }
    }
}
