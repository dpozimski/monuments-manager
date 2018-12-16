using MediatR;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Application.Infrastructure;
using Monuments.Manager.Application.Pictures.Extensions;
using Monuments.Manager.Domain.Entities;
using Monuments.Manager.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Pictures.Commands
{
    public class CreatePictureCommandHandler : IRequestHandler<CreatePictureCommand, int>
    {
        private readonly MonumentsDbContext _dbContext;
        private readonly IPictureDtoFactory _pictureDtoFactory;

        public CreatePictureCommandHandler(MonumentsDbContext dbContext,
                                           IPictureDtoFactory pictureDtoFactory)
        {
            _dbContext = dbContext;
            _pictureDtoFactory = pictureDtoFactory;
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

            var pictureEntity = new PictureEntity()
            {
                Data = request.Data.Decode(),
                Description = request.Description
            };

            monumentEntity.Pictures.Add(pictureEntity);

            await _dbContext.SaveChangesAsync();

            return pictureEntity.Id;
        }
    }
}
