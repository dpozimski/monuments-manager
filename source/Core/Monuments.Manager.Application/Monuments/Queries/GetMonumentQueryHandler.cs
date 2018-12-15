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
        private readonly IImageFactory _imageFactory;

        public GetMonumentQueryHandler(MonumentsDbContext dbContext,
                                       IImageFactory imageFactory)
        {
            _dbContext = dbContext;
            _imageFactory = imageFactory;
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

            return monumentEntity.ToDto(_imageFactory);
        }
    }
}
