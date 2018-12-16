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
        private readonly IPictureDtoFactory _pictureDtoFactory;

        public GetRecentMonumentsQueryHandler(MonumentsDbContext dbContext,
                                              IPictureDtoFactory thumbnailImageFactory)
        {
            _dbContext = dbContext;
            _pictureDtoFactory = thumbnailImageFactory;
        }

        public async Task<List<MonumentPreviewDto>> Handle(GetRecentMonumentsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Monuments
                .Include(s => s.User)
                .Include(s => s.Pictures)
                .OrderByDescending(s => s.ModifiedDate)
                .Take(request.RecentMonumentsCount)
                .Select(s => s.ToPreviewDto(_pictureDtoFactory.Convert(s.Pictures.FirstOrDefault(), false)))
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
