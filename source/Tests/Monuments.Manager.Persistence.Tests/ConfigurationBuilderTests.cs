using AutoFixture;
using AutoFixture.AutoNSubstitute;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Persistence.Configurations;
using Monuments.Manager.Persistence.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Monuments.Manager.Persistence.Tests
{
    public class ConfigurationBuilderTests
    {
        [Fact]
        public void ApplyConfiguration_ShouldRegisterAllConfiguration()
        {
            //arrange
            var fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            var configurationBuilder = fixture.Create<ConfigurationBuilder>();
            var modelBuilderMock = fixture.Create<ModelBuilderMock>();

            //act
            configurationBuilder.ApplyConfiguration(modelBuilderMock);

            //assert
            modelBuilderMock.Configurations
                .Select(s => s.GetType())
                .Should()
                .BeEquivalentTo(GetConfigurationTypesFromAssembly());
        }

        private ICollection<Type> GetConfigurationTypesFromAssembly()
        {
            return typeof(ConfigurationBuilder).Assembly
                .GetTypes()
                .Where(s => !s.IsAbstract)
                .Where(t => t.GetInterfaces().Any(i => i.Name.Equals(typeof(IEntityTypeConfiguration<>).Name, StringComparison.Ordinal)))
                .ToList();
        }
    }
}
