using MediatR;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Application.Monuments.Models;
using Monuments.Manager.Domain.Entities;
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

            IEnumerable<MonumentPreviewDto> monuments = _dbContext.Monuments
                .Include(s => s.User)
                .Include(s => s.Pictures)
                .Include(s => s.Address)
                .Where(s => request.Filter == null || 
                            EF.Functions.Like(s.Name, $"{request.Filter}%") ||
                            EF.Functions.Like(s.Address.Area, $"{request.Filter}%") ||
                            EF.Functions.Like(s.Address.City, $"{request.Filter}%") ||
                            EF.Functions.Like(s.Address.Commune, $"{request.Filter}%") ||
                            EF.Functions.Like(s.Address.District, $"{request.Filter}%") ||
                            EF.Functions.Like(s.Address.Province, $"{request.Filter}%") ||
                            EF.Functions.Like(s.Address.Street, $"{request.Filter}%") ||
                            EF.Functions.Like(s.FormOfProtection, $"{request.Filter}%"))
                .Skip(request.PageSize * request.PageNumber)
                .Take(request.PageSize)
                .OrderBy(s => s.Name)
                .Select(s => new MonumentPreviewDto()
                {
                    Id = s.Id,
                    ConstructionDate = s.ConstructionDate,
                    Name = s.Name,
                    OwnerId = s.UserId,
                    OwnerName = s.User.Email,
                    Picture = s.Pictures.Count > 0 ? s.Pictures.FirstOrDefault().Data : null
                });

            if (request.DescSortOrder)
            {
                monuments = monuments.OrderByDescending(s => s.Name);
            }

            return new GetMonumentsQueryResult()
            {
                PagesCount = pages,
                Monuments = monuments.ToList()
            };
        }
    }
}
