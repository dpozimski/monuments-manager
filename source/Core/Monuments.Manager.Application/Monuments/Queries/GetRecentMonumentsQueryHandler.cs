using MediatR;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Application.Infrastructure;
using Monuments.Manager.Application.Monuments.Models;
using Monuments.Manager.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Monuments.Queries
{
    public class GetRecentMonumentsQueryHandler : IRequestHandler<GetRecentMonumentsQuery, List<MonumentDto>>
    {
        private readonly MonumentsDbContext _dbContext;
        private readonly IImageFactory _thumbnailImageFactory;

        public GetRecentMonumentsQueryHandler(MonumentsDbContext dbContext,
                                              IImageFactory thumbnailImageFactory)
        {
            _dbContext = dbContext;
            _thumbnailImageFactory = thumbnailImageFactory;
        }

        public async Task<List<MonumentDto>> Handle(GetRecentMonumentsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Monuments
                .Include(s => s.User)
                .Include(s => s.Pictures)
                .OrderByDescending(s => s.ModifiedDate)
                .Take(request.RecentMonumentsCount)
                .Select(s => new MonumentDto()
                {
                    Id = s.Id,
                    ConstructionDate = s.ConstructionDate,
                    Name = s.Name,
                    OwnerId = s.UserId,
                    OwnerName = s.User.Email,
                    Picture = s.Pictures.Count > 0 ? _thumbnailImageFactory.CreateThumbnail(s.Pictures.FirstOrDefault().Data) : null
                }).ToListAsync(cancellationToken);

            return result;
        }
    }
}
