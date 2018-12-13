using MediatR;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Application.Infrastructure;
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
        private readonly IImageFactory _imageFactory;

        public CreatePictureCommandHandler(MonumentsDbContext dbContext,
                                           IImageFactory imageFactory)
        {
            _dbContext = dbContext;
            _imageFactory = imageFactory;
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

            var pictureEntity = new PictureEntity() { Data = _imageFactory.Decode(request.Data) };

            monumentEntity.Pictures.Add(pictureEntity);

            await _dbContext.SaveChangesAsync();

            return pictureEntity.Id;
        }
    }
}
