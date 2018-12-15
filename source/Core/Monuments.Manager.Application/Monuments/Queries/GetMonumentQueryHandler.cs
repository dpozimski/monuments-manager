using MediatR;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Application.Infrastructure;
using Monuments.Manager.Application.Monuments.Extensions;
using Monuments.Manager.Application.Monuments.Models;
using Monuments.Manager.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Monuments.Queries
{
    public class GetMonumentQueryHandler : IRequestHandler<GetMonumentQuery, MonumentDto>
    {
        private readonly MonumentsDbContext _dbContext;
        private readonly IPictureDtoFactory _pictureDtoFactory;

        public GetMonumentQueryHandler(MonumentsDbContext dbContext,
                                       IPictureDtoFactory pictureDtoFactory)
        {
            _dbContext = dbContext;
            _pictureDtoFactory = pictureDtoFactory;
        }

        public async Task<MonumentDto> Handle(GetMonumentQuery request, CancellationToken cancellationToken)
        {
            var monumentEntity = await _dbContext.Monuments
                .Include(s => s.Address)
                .Include(s => s.Pictures)
                .FirstOrDefaultAsync(s => s.Id == request.MonumentId);

            if(monumentEntity is null)
            {
                throw new MonumentsManagerAppException(ExceptionType.EntityNotFound, $"Entity of type MonumentEntity with id {request.MonumentId} does not exists");
            }

            var pictures = monumentEntity.Pictures
                .Select(s => _pictureDtoFactory.Convert(s, true))
                .ToList();

            return monumentEntity.ToDto(pictures);
        }
    }
}
