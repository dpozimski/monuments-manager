﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monuments.Manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.Password)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.JobTitle)
                .HasMaxLength(50);
        }
    }
}