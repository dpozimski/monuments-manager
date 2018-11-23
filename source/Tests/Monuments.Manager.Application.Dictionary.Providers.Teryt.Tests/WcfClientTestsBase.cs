using AutoFixture;
using FluentAssertions;
using Monuments.Manager.Application.Dictionary.Providers.Teryt.Client;
using Monuments.Manager.Dictionary.Providers.Teryt.WebService;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Monuments.Manager.Application.Dictionary.Providers.Teryt.Tests
{
    public abstract class WcfClientTestsBase<TClientImpl> where TClientImpl : IWcfClient
    {
        private readonly TClientImpl _target;

        public WcfClientTestsBase()
        {
            var terytWs1 = Substitute.For<ITerytWs1>();
            _target = (TClientImpl)Activator.CreateInstance(typeof(TClientImpl), terytWs1);
        }

        [Fact]
        public async Task GetProvincesAsync_ShouldReturnProvinces()
        {
            //arrange
            var fixture = new Fixture();
            var response = fixture.Create<PobierzListeWojewodztwResponse>();
            var terytWs1 = Substitute.For<ITerytWs1>();
            terytWs1.PobierzListeWojewodztwAsync(Arg.Any<PobierzListeWojewodztwRequest>())
                .Returns(Task.FromResult(response));
            var wcfClient = new WcfClient(terytWs1);
            //act
            var result = await wcfClient.GetProvincesAsync();
            //assert
            result.Should().Be(response);
        }

        [Fact]
        public async Task GetDistrictsAsync_ShouldReturnDistricts()
        {
            //arrange
            var fixture = new Fixture();
            var response = fixture.Create<PobierzListePowiatowResponse>();
            var terytWs1 = Substitute.For<ITerytWs1>();
            terytWs1.PobierzListePowiatowAsync(Arg.Any<PobierzListePowiatowRequest>())
                .Returns(Task.FromResult(response));
            var wcfClient = new WcfClient(terytWs1);
            //act
            var result = await wcfClient.GetDistrictsAsync("TEST");
            //assert
            result.Should().Be(response);
        }

        [Fact]
        public async Task GetCommunesAsync_ShouldReturnCommunes()
        {
            //arrange
            var fixture = new Fixture();
            var response = fixture.Create<PobierzListeGminResponse>();
            var terytWs1 = Substitute.For<ITerytWs1>();
            terytWs1.PobierzListeGminAsync(Arg.Any<PobierzListeGminRequest>())
                .Returns(Task.FromResult(response));
            var wcfClient = new WcfClient(terytWs1);
            //act
            var result = await wcfClient.GetCommunesAsync("TEST", "TEST");
            //assert
            result.Should().Be(response);
        }

        [Fact]
        public async Task GetCitiesAsync_ShouldReturnCities()
        {
            //arrange
            var fixture = new Fixture();
            var response = fixture.Create<PobierzListeMiejscowosciWGminieResponse>();
            var terytWs1 = Substitute.For<ITerytWs1>();
            terytWs1.PobierzListeMiejscowosciWGminieAsync(Arg.Any<PobierzListeMiejscowosciWGminieRequest>())
                .Returns(Task.FromResult(response));
            var wcfClient = new WcfClient(terytWs1);
            //act
            var result = await wcfClient.GetCitiesAsync("TEST", "TEST", "TEST");
            //assert
            result.Should().Be(response);
        }

        [Fact]
        public async Task GetStreetsAsync_ShouldReturnStreets()
        {
            //arrange
            var fixture = new Fixture();
            var response = fixture.Create<PobierzListeUlicDlaMiejscowosciResponse>();
            var terytWs1 = Substitute.For<ITerytWs1>();
            terytWs1.PobierzListeUlicDlaMiejscowosciAsync(Arg.Any<PobierzListeUlicDlaMiejscowosciRequest>())
                .Returns(Task.FromResult(response));
            var wcfClient = new WcfClient(terytWs1);
            //act
            var result = await wcfClient.GetStreetsAsync("TEST", "TEST", "TEST", "TEST");
            //assert
            result.Should().Be(response);
        }
    }
}
