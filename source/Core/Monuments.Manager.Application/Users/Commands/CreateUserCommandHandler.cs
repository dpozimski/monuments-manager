using MediatR;
using Monuments.Manager.Application.Infrastructure;
using Monuments.Manager.Application.Infrastructure.Encryption;
using Monuments.Manager.Domain.Entities;
using Monuments.Manager.Domain.Enumerations;
using Monuments.Manager.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly MonumentsDbContext _dbContext;
        private readonly IPasswordEncryptor _passwordEncryptor;

        public CreateUserCommandHandler(MonumentsDbContext dbContext,
                                        IPasswordEncryptor passwordEncryptor)
        {
            _dbContext = dbContext;
            _passwordEncryptor = passwordEncryptor;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new UserEntity()
            {
                Password = _passwordEncryptor.Encrypt(request.Password),
                Username = request.Username,
                JobTitle = request.JobTitle,
                Role = request.Role.ConvertTo<UserRole>()
            };

            var result = await _dbContext.AddAsync(entity, cancellationToken);

            return result.Entity.Id;
        }
    }
}
