using MediatR;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Application.Pictures.Extensions;
using Monuments.Manager.Application.Pictures.Models;
using Monuments.Manager.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Pictures.Query
{
    public class GetPictureByIdQueryHandler : IRequestHandler<GetPictureByIdQuery, PictureDto>
    {
        private readonly MonumentsDbContext _dbContext;

        public GetPictureByIdQueryHandler(MonumentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PictureDto> Handle(GetPictureByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Pictures.FindAsync(request.Id);

            if(entity is null)
            {
                throw new MonumentsManagerAppException(ExceptionType.EntityNotFound, $"Cannot find picture by id {request.Id}");
            }

            return entity.ToDto();
        }
    }
}
