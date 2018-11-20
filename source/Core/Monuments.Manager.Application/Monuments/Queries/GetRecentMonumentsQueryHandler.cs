using MediatR;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Application.Monuments.Models;
using Monuments.Manager.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                .Include(s => s.Pictures)
                .OrderByDescending(s => s.ModifiedDate)
                .Take(request.RecentMonumentsCount)
                .Select(s => new MonumentPreviewDto()
                {
                    Id = s.Id,
                    ConstructionDate = s.ConstructionDate,
                    Name = s.Name,
                    OwnerId = s.UserId,
                    OwnerName = s.User.Username,
                    Picture = s.Pictures.Count > 0 ? s.Pictures.FirstOrDefault().Data : null
                }).ToListAsync(cancellationToken);

            return result;
        }
    }
}
