using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Monuments.Manager.Infrastructure.Tests
{
    public class SystemDateTimeProviderTests
    {
        [Fact]
        public void GetCurrent_ShouldBAssertionValue()
        {
            //arrange
            var systemDateTimeProvider = new SystemDateTimeProvider();
            //act
            var result = systemDateTimeProvider.GetCurrent();
            //assert
            result.Day.Should().Be(DateTime.UtcNow.Day);
        }
    }
}
