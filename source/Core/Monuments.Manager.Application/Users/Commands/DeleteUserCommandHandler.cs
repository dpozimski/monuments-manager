using MediatR;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Application.Infrastructure;
using Monuments.Manager.Domain.Entities;
using Monuments.Manager.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Users.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly MonumentsDbContext _dbContext;
        private readonly IApplicationContext _context;

        public DeleteUserCommandHandler(MonumentsDbContext dbContext,
                                        IApplicationContext context)
        {
            _dbContext = dbContext;
            _context = context;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FindAsync(request.Id);

            if (entity is null)
            {
                throw new MonumentsManagerAppException(ExceptionType.EntityNotFound, $"Entity of type UserEntity with id {request.Id} does not exists");
            }

            if (_context.UserId == request.Id)
            {
                throw new MonumentsManagerAppException(ExceptionType.CannotDeleteCurrentUser, $"Cannot delete current user");
            }

            _dbContext.Users.Remove(entity);

            return Unit.Value;
        }
    }
}
