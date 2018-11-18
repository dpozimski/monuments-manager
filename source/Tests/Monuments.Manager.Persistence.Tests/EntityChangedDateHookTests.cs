using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using FluentAssertions;
using Monuments.Manager.Common;
using Monuments.Manager.Domain.Entities;
using NSubstitute;
using Xunit;

namespace Monuments.Manager.Persistence.Tests
{
    public class EntityChangedDateHookTests
    {
        [Fact]
        public void FillCreateDate_ShouldFillWithCurrentDateTime()
        {
            //arrange
            var fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            var date = DateTime.Parse("2018-11-10 15:15:00");
            var dateTimeProvider = fixture.Freeze<IDateTimeProvider>();
            dateTimeProvider.GetCurrent().Returns(date);
            var entityChangedDate = fixture.Create<EntityChangedDateHook>();
            var dataset = CreateDataset();
            //act
            entityChangedDate.FillCreateDate(dataset);
            //assert
            dataset.Should()
                .Contain(s => s.CreatedDate == date);
        }

        [Fact]
        public void FillModifiedDate_ShouldFillWithCurrentDateTime()
        {
            //arrange
            var fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            var date = DateTime.Parse("2018-11-10 15:15:00");
            var dateTimeProvider = fixture.Freeze<IDateTimeProvider>();
            dateTimeProvider.GetCurrent().Returns(date);
            var entityChangedDate = fixture.Create<EntityChangedDateHook>();
            var dataset = CreateDataset();
            //act
            entityChangedDate.FillModifiedDate(dataset);
            //assert
            dataset.Should()
                .Contain(s => s.ModifiedDate == date);
        }

        private IEnumerable<BaseEntity> CreateDataset()
        {
            var list = new List<BaseEntity>();

            for(int i = 0; i < 100; i++)
            {
                list.Add(new BaseEntity()
                {
                    Id = i
                });
            }

            return list;
        }
    }
}
