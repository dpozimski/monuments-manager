using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Application.Infrastructure.Models;
using Monuments.Manager.Application.Users.Commands;
using Monuments.Manager.Application.Users.Queries;
using Monuments.Manager.ViewModels;

namespace Monuments.Manager.Infrastructure
{
    public class JwtAuthenticationService : IAuthenticationService
    {
        private readonly IMediator _mediator;
        private readonly IOptions<ApplicationSecurityOptions> _options;

        public JwtAuthenticationService(IMediator mediator,
                                        IOptions<ApplicationSecurityOptions> options)
        {
            _mediator = mediator;
            _options = options;
        }

        public async Task<string> AuthenticateAsync(AuthenticateUserViewModel viewModel)
        {
            var authenticatedUserId = await _mediator.Send(new AuthenticateUserCommand()
            {
                Username = viewModel.Username,
                Password = viewModel.Password
            });

            if (!authenticatedUserId.HasValue)
                throw new AuthenticationException(viewModel.Username);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Value.JwtSecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, authenticatedUserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
