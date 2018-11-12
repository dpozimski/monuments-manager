using MediatR;
using Monuments.Manager.Application.Context;
using Monuments.Manager.Application.Exceptions;
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
        private readonly ApplicationContext _context;

        public DeleteUserCommandHandler(MonumentsDbContext dbContext,
                                        ApplicationContext context)
        {
            _dbContext = dbContext;
            _context = context;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FindAsync(new object[] { request.Id }, cancellationToken: cancellationToken);

            if (entity is null)
            {
                throw new EntityNotFoundException<MonumentEntity>(request.Id);
            }

            if (_context.UserId == request.Id)
            {
                throw new CannotDeleteCurrentUserException(entity.Id, entity.Username);
            }

            _dbContext.Users.Remove(entity);

            return Unit.Value;
        }
    }
}
