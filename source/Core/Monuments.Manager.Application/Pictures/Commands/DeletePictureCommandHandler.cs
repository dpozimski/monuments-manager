using MediatR;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Domain.Entities;
using Monuments.Manager.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Pictures.Commands
{
    public class DeletePictureCommandHandler : IRequestHandler<DeletePictureCommand>
    {
        private readonly MonumentsDbContext _dbContext;

        public DeletePictureCommandHandler(MonumentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeletePictureCommand request, CancellationToken cancellationToken)
        {
            var pictureEntity = await _dbContext.Pictures.FindAsync(request.PictureId);

            if (pictureEntity is null)
            {
                throw new MonumentsManagerAppException(ExceptionType.EntityNotFound, $"Entity of type PictureEntity with id {request.PictureId} does not exists");
            }

            _dbContext.Pictures.Remove(pictureEntity);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
