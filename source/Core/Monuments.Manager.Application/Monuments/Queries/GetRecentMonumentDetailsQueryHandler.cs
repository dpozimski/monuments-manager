using MediatR;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Application.Monuments.Extensions;
using Monuments.Manager.Application.Monuments.Models;
using Monuments.Manager.Domain.Entities;
using Monuments.Manager.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Monuments.Queries
{
    public class GetRecentMonumentDetailsQueryHandler : IRequestHandler<GetRecentMonumentDetailsQuery, MonumentDto>
    {
        private readonly MonumentsDbContext _dbContext;

        public GetRecentMonumentDetailsQueryHandler(MonumentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MonumentDto> Handle(GetRecentMonumentDetailsQuery request, CancellationToken cancellationToken)
        {
            var monumentEntity = await _dbContext.Monuments
                .FindAsync(request.MonumentId);

            if(monumentEntity is null)
            {
                throw new MonumentsManagerAppException(ExceptionType.EntityNotFound, $"Entity of type MonumentEntity with id {request.MonumentId} does not exists");
            }

            return monumentEntity.ToDto(new List<PictureEntity>());
        }
    }
}
