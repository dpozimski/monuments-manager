using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class CreatePictureCommandHandler : IRequestHandler<CreatePictureCommand, int>
    {
        private readonly MonumentsDbContext _dbContext;

        public CreatePictureCommandHandler(MonumentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreatePictureCommand request, CancellationToken cancellationToken)
        {
            var monumentEntity = await _dbContext.Monuments
                .Include(s => s.Pictures)
                .FirstOrDefaultAsync(s => s.Id == request.MonumentId);

            if(monumentEntity is null)
            {
                throw new MonumentsManagerAppException(ExceptionType.EntityNotFound, $"Entity of type MonumentEntity with id {request.MonumentId} does not exists");
            }

            var pictureEntity = new PictureEntity() { Data = request.Data };

            monumentEntity.Pictures.Add(new PictureEntity() { Data = request.Data });

            await _dbContext.SaveChangesAsync();

            return pictureEntity.Id;
        }
    }
}
