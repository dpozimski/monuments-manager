using MediatR;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Application.Infrastructure;
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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly MonumentsDbContext _dbContext;
        private readonly IPasswordEncryptor _passwordEncryptor;

        public UpdateUserCommandHandler(MonumentsDbContext dbContext,
                                        IPasswordEncryptor passwordEncryptor)
        {
            _dbContext = dbContext;
            _passwordEncryptor = passwordEncryptor;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FindAsync(request.Id);

            if (entity is null)
            {
                throw new EntityNotFoundException<UserEntity>(request.Id);
            }

            entity.Password = _passwordEncryptor.Encrypt(request.Password);
            entity.JobTitle = request.JobTitle;
            entity.Role = request.Role.ConvertTo<UserRole>();

            _dbContext.Users.Update(entity);

            return Unit.Value;
        }
    }
}
