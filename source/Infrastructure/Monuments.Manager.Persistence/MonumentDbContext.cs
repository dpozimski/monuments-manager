using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Persistence
{
    public class MonumentDbContext : DbContext
    {
        private readonly IConfigurationBuilder _configurationBuilder;

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<MonumentEntity> Monuments { get; set; }
        public DbSet<PictureEntity> Pictures { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }


        public DbSet<ProvinceEntity> Provinces { get; set; }
        public DbSet<DistrictEntity> Districts { get; set; }
        public DbSet<CommuneEntity> Communes { get; set; }
        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<StreetEntity> Streets { get; set; }

        public MonumentDbContext(
            IConfigurationBuilder configurationBuilder,
            DbContextOptions options) : base(options)
        {
            _configurationBuilder = configurationBuilder;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _configurationBuilder.ApplyConfiguration(modelBuilder);
        }
    }
}
