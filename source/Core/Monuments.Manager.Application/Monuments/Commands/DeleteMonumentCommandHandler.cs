using MediatR;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Domain.Entities;
using Monuments.Manager.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var entity = await _dbContext.Monuments.FindAsync(request.MonumentId);

            if(entity is null)
            {
                throw new MonumentsManagerAppException(ExceptionType.EntityNotFound, $"Entity of type MonumentEntity with id {request.MonumentId} does not exists");
            }

            _dbContext.Monuments.Remove(entity);

            var addressEntity = await _dbContext.Addresses
                .FirstOrDefaultAsync(s => s.MonumentId == request.MonumentId);

            _dbContext.Addresses.Remove(addressEntity);

            var pictures = await _dbContext.Pictures.Where(s => s.MonumentId == request.MonumentId)
                .ToListAsync();

            _dbContext.Pictures.RemoveRange(pictures);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
