using AutoFixture;
using FluentAssertions;
using Monuments.Manager.Application.Dictionary.Providers.Teryt.Client;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Monuments.Manager.Application.Dictionary.Providers.Teryt.Tests
{
    public class WcfClientScopeFactoryTests
    {
        [Fact]
        public void Client_ShouldBeTheSameAsConstructorParameter()
        {
            //arrange
            var wcfClient = Substitute.For<IWcfClient>();
            var wcfClientScope = new WcfClientScope(wcfClient, new Action(() => { }));
            //act
            var client = wcfClientScope.Client;
            //assert
            client.Should().Be(wcfClient);
        }
    }
}
