using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Persistence
{
    public class MonumentDbContext : DbContext
    {
        private readonly IConfigurationBuilder _configurationBuilder;
        private readonly IEntityChangedDateHook _entityChangedDateHook;

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
            IEntityChangedDateHook entityChangedDateHook,
            DbContextOptions options) : base(options)
        {
            _configurationBuilder = configurationBuilder;
            _entityChangedDateHook = entityChangedDateHook;
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var addedEntities = ChangeTracker.Entries()
                .Where(s => s.State == EntityState.Added)
                .Select(s => s.Entity)
                .OfType<BaseEntity>()
                .ToList();

            _entityChangedDateHook.FillCreateDate(addedEntities);

            var changedEntities = ChangeTracker.Entries()
                .Where(s => s.State == EntityState.Added)
                .Select(s => s.Entity)
                .OfType<BaseEntity>()
                .ToList();

            _entityChangedDateHook.FillModifiedDate(changedEntities);

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _configurationBuilder.ApplyConfiguration(modelBuilder);
        }
    }
}
