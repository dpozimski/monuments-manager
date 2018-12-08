using MediatR;
using Monuments.Manager.Application.Exceptions;
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
                throw new MonumentsManagerAppException(ExceptionType.EntityNotFound, $"Entity of type UserEntity with id {request.Id} does not exists");
            }

            entity.Password = _passwordEncryptor.Encrypt(request.Password);
            entity.JobTitle = request.JobTitle;
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;

            _dbContext.Users.Update(entity);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
