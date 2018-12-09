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
    public class GetMonumentsQueryHandler : IRequestHandler<GetMonumentsQuery, GetMonumentsQueryResult>
    {
        private readonly MonumentsDbContext _dbContext;

        public GetMonumentsQueryHandler(MonumentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetMonumentsQueryResult> Handle(GetMonumentsQuery request, CancellationToken cancellationToken)
        {
            var count = await _dbContext.Monuments.CountAsync();

            var monumentsCount = await _dbContext.Monuments.CountAsync();
            var pages = monumentsCount / request.PageSize;

            var monuments = await _dbContext.Monuments
                .Include(s => s.User)
                .Include(s => s.Pictures)
                .Skip(request.PageSize * request.PageNumber)
                .Take(request.PageSize)
                .Select(s => new MonumentPreviewDto()
                {
                    Id = s.Id,
                    ConstructionDate = s.ConstructionDate,
                    Name = s.Name,
                    OwnerId = s.UserId,
                    OwnerName = s.User.Email,
                    Picture = s.Pictures.Count > 0 ? s.Pictures.FirstOrDefault().Data : null
                }).ToListAsync(cancellationToken);

            return new GetMonumentsQueryResult()
            {
                PagesCount = pages,
                Monuments = monuments
            };
        }
    }
}
