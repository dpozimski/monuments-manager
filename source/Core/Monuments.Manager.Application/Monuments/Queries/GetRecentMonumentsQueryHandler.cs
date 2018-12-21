using MediatR;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Application.Infrastructure;
using Monuments.Manager.Application.Monuments.Extensions;
using Monuments.Manager.Application.Monuments.Models;
using Monuments.Manager.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Monuments.Queries
{
    public class GetRecentMonumentsQueryHandler : IRequestHandler<GetRecentMonumentsQuery, List<MonumentPreviewDto>>
    {
        private readonly MonumentsDbContext _dbContext;

        public GetRecentMonumentsQueryHandler(MonumentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MonumentPreviewDto>> Handle(GetRecentMonumentsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Monuments
                .Include(s => s.User)
                .Include(s => s.Address)
                .OrderByDescending(s => s.ModifiedDate)
                .Take(request.RecentMonumentsCount)
                .Select(s => s.ToPreviewDto(s.Pictures.FirstOrDefault()))
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
