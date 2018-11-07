using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Persistence.Tests.Mocks
{
    public class ModelBuilderMock : ModelBuilder
    {
        public ICollection<object> Configurations { get; }

        public ModelBuilderMock() : base(new ConventionSet())
        {
            Configurations = new HashSet<object>();
        }

        public override ModelBuilder ApplyConfiguration<TEntity>(IEntityTypeConfiguration<TEntity> configuration)
        {
            Configurations.Add(configuration);

            return this;
        }
    }
}
