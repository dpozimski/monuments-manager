using AutoFixture;
using AutoFixture.AutoNSubstitute;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.Options;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Application.Infrastructure.Models;
using Monuments.Manager.Application.Users.Commands;
using Monuments.Manager.Application.Users.Models;
using Monuments.Manager.Common;
using Monuments.Manager.Infrastructure.Security;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Monuments.Manager.Infrastructure.Tests
{
    public class JwtAuthenticationServiceTests
    {
        [Fact]
        public async Task AuthenticateAsync_ShouldReturnTokenIfAuthenticated()
        {
            //arrange
            var userDto = new UserDto() { Id = 1 };
            var fixture = CreateFixture(userDto);
            var target = fixture.Create<JwtAuthenticationService>();
            //act
            var result = await target.AuthenticateAsync("TEST", "TEST");
            //assert
            result.Should().NotBeNull();
            result.User.Should().Be(userDto);
        }

        [Fact]
        public void AuthenticateAsync_ShouldThrowAuthenticationExceptionIfNotAuthenticated()
        {
            //arrange
            var fixture = CreateFixture(null);
            var target = fixture.Create<JwtAuthenticationService>();
            //act
            Func<Task> actAction = async () => await target.AuthenticateAsync("TEST", "TEST");
            //assert
            actAction.Should().Throw<AuthenticationException>();
        }

        private IFixture CreateFixture(UserDto userDto)
        {
            var fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            var options = fixture.Freeze<IOptions<ApplicationSecurityOptions>>();
            options.Value.Returns(new ApplicationSecurityOptions() { JwtSecretKey = "TESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTEST" });
            var dateTimeProvider = fixture.Freeze<IDateTimeProvider>();
            dateTimeProvider.GetCurrent().Returns(new DateTime(2019, 11, 11));
            var mediator = fixture.Freeze<IMediator>();
            mediator.Send(Arg.Any<AuthenticateUserCommand>()).Returns(userDto);

            return fixture;
        }
    }
}
