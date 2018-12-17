using MediatR;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Application.Infrastructure;
using Monuments.Manager.Application.Pictures.Extensions;
using Monuments.Manager.Application.Pictures.Models;
using Monuments.Manager.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Pictures.Commands
{
    public class CreatePictureCommandHandler : IRequestHandler<CreatePictureCommand, PictureDto>
    {
        private readonly MonumentsDbContext _dbContext;
        private readonly IPictureFactory _pictureFactory;

        public CreatePictureCommandHandler(MonumentsDbContext dbContext,
                                           IPictureFactory pictureFactory)
        {
            _dbContext = dbContext;
            _pictureFactory = pictureFactory;
        }

        public async Task<PictureDto> Handle(CreatePictureCommand request, CancellationToken cancellationToken)
        {
            var monumentEntity = await _dbContext.Monuments
                .Include(s => s.Pictures)
                .FirstOrDefaultAsync(s => s.Id == request.MonumentId);

            if(monumentEntity is null)
            {
                throw new MonumentsManagerAppException(ExceptionType.EntityNotFound, $"Entity of type MonumentEntity with id {request.MonumentId} does not exists");
            }

            var pictureEntity = _pictureFactory.Create(request);

            monumentEntity.Pictures.Add(pictureEntity);

            await _dbContext.SaveChangesAsync();

            return pictureEntity.ToDto();
        }
    }
}
