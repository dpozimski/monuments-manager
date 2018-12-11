using MediatR;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Application.Monuments.Models;
using Monuments.Manager.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Monuments.Queries
{
    public class GetMonumentsStatsQueryHandler : IRequestHandler<GetMonumentsStatsQuery, GetMonumentsStatsQueryResult>
    {
        private readonly MonumentsDbContext _dbContext;

        public GetMonumentsStatsQueryHandler(MonumentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetMonumentsStatsQueryResult> Handle(GetMonumentsStatsQuery request, CancellationToken cancellationToken)
        {
            var monumentsCount = await _dbContext.Monuments.CountAsync();

            return new GetMonumentsStatsQueryResult()
            {
                MonumentsCount = monumentsCount
            };
        }
    }
}
