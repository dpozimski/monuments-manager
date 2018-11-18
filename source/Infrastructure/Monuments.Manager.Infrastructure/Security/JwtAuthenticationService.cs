using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Application.Infrastructure.Models;
using Monuments.Manager.Application.Users.Commands;
using Monuments.Manager.Common;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Monuments.Manager.Infrastructure.Security
{
    public class JwtAuthenticationService : IAuthenticationService
    {
        private readonly IMediator _mediator;
        private readonly IOptions<ApplicationSecurityOptions> _options;
        private readonly IDateTimeProvider _dateTimeProvider;

        public JwtAuthenticationService(IMediator mediator,
                                        IOptions<ApplicationSecurityOptions> options,
                                        IDateTimeProvider dateTimeProvider)
        {
            _mediator = mediator;
            _options = options;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<string> AuthenticateAsync(string username, string password)
        {
            var authenticatedUserId = await _mediator.Send(new AuthenticateUserCommand()
            {
                Username = username,
                Password = password
            });

            if (!authenticatedUserId.HasValue)
                throw new AuthenticationException(username);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Value.JwtSecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, authenticatedUserId.ToString())
                }),
                Expires = _dateTimeProvider.GetCurrent().AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
