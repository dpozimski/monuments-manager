using MediatR;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Application.Infrastructure.Encryption;
using Monuments.Manager.Application.Users.Models;
using Monuments.Manager.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Users.Commands
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, int?>
    {
        private readonly MonumentsDbContext _dbContext;
        private readonly IPasswordEncryptor _passwordEncryptor;

        public AuthenticateUserCommandHandler(MonumentsDbContext dbContext,
                                              IPasswordEncryptor passwordEncryptor)
        {
            _dbContext = dbContext;
            _passwordEncryptor = passwordEncryptor;
        }

        public async Task<int?> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var encryptedPassword = _passwordEncryptor.Encrypt(request.Password);

            var user = await _dbContext.Users
                .FirstOrDefaultAsync(s => s.Username == request.Username && s.Password == encryptedPassword);

            return user?.Id;
        }
    }
}
