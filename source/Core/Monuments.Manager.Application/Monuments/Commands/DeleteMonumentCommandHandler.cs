using MediatR;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Domain.Entities;
using Monuments.Manager.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Monuments.Commands
{
    public class DeleteMonumentCommandHandler : IRequestHandler<DeleteMonumentCommand>
    {
        private readonly MonumentsDbContext _dbContext;

        public DeleteMonumentCommandHandler(MonumentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteMonumentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Monuments.FindAsync(request.Id);

            if(entity is null)
            {
                throw new EntityNotFoundException<MonumentEntity>(request.Id);
            }

            _dbContext.Monuments.Remove(entity);

            return Unit.Value;
        }
    }
}
