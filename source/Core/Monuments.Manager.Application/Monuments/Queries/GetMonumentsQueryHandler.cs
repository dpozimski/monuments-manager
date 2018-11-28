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
    public class GetMonumentsQueryHandler : IRequestHandler<GetMonumentsQuery, GetMonumentdQueryResult>
    {
        private readonly MonumentsDbContext _dbContext;

        public GetMonumentsQueryHandler(MonumentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetMonumentdQueryResult> Handle(GetMonumentsQuery request, CancellationToken cancellationToken)
        {
            var count = await _dbContext.Monuments.CountAsync();

            var monuments = await _dbContext.Monuments
                .Include(s => s.User)
                .Include(s => s.Pictures)
                .Skip(request.StartIndex)
                .Take(request.EndIndex)
                .Select(s => new MonumentPreviewDto()
                {
                    Id = s.Id,
                    ConstructionDate = s.ConstructionDate,
                    Name = s.Name,
                    OwnerId = s.UserId,
                    OwnerName = s.User.Email,
                    Picture = s.Pictures.Count > 0 ? s.Pictures.FirstOrDefault().Data : null
                }).ToListAsync(cancellationToken);

            var leftCount = count - request.EndIndex;

            return new GetMonumentdQueryResult()
            {
                LeftCount = leftCount,
                Monuments = monuments
            };
        }
    }
}
