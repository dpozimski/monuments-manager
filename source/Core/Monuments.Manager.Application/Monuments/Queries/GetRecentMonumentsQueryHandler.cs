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
    public class GetRecentMonumentsQueryHandler : IRequestHandler<GetRecentMonumentsQuery, List<RecentMonumentDto>>
    {
        private readonly MonumentsDbContext _monumentDbContext;

        public GetRecentMonumentsQueryHandler(MonumentsDbContext monumentDbContext)
        {
            _monumentDbContext = monumentDbContext;
        }

        public async Task<List<RecentMonumentDto>> Handle(GetRecentMonumentsQuery request, CancellationToken cancellationToken)
        {
            var result = await _monumentDbContext.Monuments
                .Include(s => s.User)
                .Include(s => s.Pictures)
                .Select(s => new RecentMonumentDto()
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
