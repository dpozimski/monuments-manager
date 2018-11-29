using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Application.Infrastructure.Models;
using Monuments.Manager.Application.Users.Commands;
using Monuments.Manager.Common;
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

        public async Task<UserToken> AuthenticateAsync(string email, string password)
        {
            var authenticatedUser = await _mediator.Send(new AuthenticateUserCommand()
            {
                Email = email,
                Password = password
            });

            if (authenticatedUser is null)
                throw new MonumentsManagerAppException(ExceptionType.AuthenticationFail, $"User with id {email} is not authenticated to execute current operation");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Value.JwtSecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, authenticatedUser.ToString())
                }),
                Expires = _dateTimeProvider.GetCurrent().AddDays(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new UserToken()
            {
                User = authenticatedUser,
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
