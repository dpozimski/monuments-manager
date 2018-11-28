using MediatR;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Application.Infrastructure;
using Monuments.Manager.Application.Infrastructure.Encryption;
using Monuments.Manager.Application.Users.Models;
using Monuments.Manager.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Users.Commands
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, UserDto>
    {
        private readonly MonumentsDbContext _dbContext;
        private readonly IPasswordEncryptor _passwordEncryptor;

        public AuthenticateUserCommandHandler(MonumentsDbContext dbContext,
                                              IPasswordEncryptor passwordEncryptor)
        {
            _dbContext = dbContext;
            _passwordEncryptor = passwordEncryptor;
        }

        public async Task<UserDto> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var encryptedPassword = _passwordEncryptor.Encrypt(request.Password);

            var user = await _dbContext.Users
                .FirstOrDefaultAsync(s => s.Email == request.Email && s.Password == encryptedPassword);

            if (user is null)
                return null;

            return new UserDto()
            {
                Id = user.Id,
                JobTitle = user.JobTitle,
                Role = user.Role.ConvertTo<UserRoleDto>(),
                Email = user.Email
            };
        }
    }
}
