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
    public class MonumentsDbContext : DbContext
    {
        private readonly IConfigurationBuilder _configurationBuilder;
        private readonly IEntityChangedDateHook _entityChangedDateHook;
        private readonly IEntityChangedUserContextHook _entityChangedUserContextHook;

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<MonumentEntity> Monuments { get; set; }
        public DbSet<PictureEntity> Pictures { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }

        public MonumentsDbContext(
            IConfigurationBuilder configurationBuilder,
            IEntityChangedDateHook entityChangedDateHook,
            IEntityChangedUserContextHook entityChangedUserContextHook,
            DbContextOptions options) : base(options)
        {
            _configurationBuilder = configurationBuilder;
            _entityChangedDateHook = entityChangedDateHook;
            _entityChangedUserContextHook = entityChangedUserContextHook;
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            var addedEntities = ChangeTracker.Entries()
                .Where(s => s.State == EntityState.Added)
                .Select(s => s.Entity)
                .OfType<BaseEntity>()
                .ToList();

            _entityChangedDateHook.FillCreateDate(addedEntities);
            _entityChangedUserContextHook.FillCreatedByUserContext(addedEntities);

            var changedEntities = ChangeTracker.Entries()
                .Where(s => s.State == EntityState.Added)
                .Select(s => s.Entity)
                .OfType<BaseEntity>()
                .ToList();

            _entityChangedDateHook.FillModifiedDate(changedEntities);
            _entityChangedUserContextHook.FillModifiedByUserContext(changedEntities);

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _configurationBuilder.ApplyConfiguration(modelBuilder);
        }
    }
}
