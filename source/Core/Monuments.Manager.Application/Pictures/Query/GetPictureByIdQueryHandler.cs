using MediatR;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Application.Infrastructure;
using Monuments.Manager.Application.Pictures.Models;
using Monuments.Manager.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Pictures.Query
{
    public class GetPictureByIdQueryHandler : IRequestHandler<GetPictureByIdQuery, PictureDto>
    {
        private readonly MonumentsDbContext _dbContext;
        private readonly IPictureDtoFactory _pictureDtoFactory;

        public GetPictureByIdQueryHandler(MonumentsDbContext dbContext,
                                          IPictureDtoFactory pictureDtoFactory)
        {
            _dbContext = dbContext;
            _pictureDtoFactory = pictureDtoFactory;
        }

        public async Task<PictureDto> Handle(GetPictureByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Pictures.FindAsync(request.Id);

            if(entity is null)
            {
                throw new MonumentsManagerAppException(ExceptionType.EntityNotFound, $"Cannot find picture by id {request.Id}");
            }

            return _pictureDtoFactory.Convert(entity, true);
        }
    }
}
