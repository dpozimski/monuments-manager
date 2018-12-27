using MediatR;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Application.Infrastructure;
using Monuments.Manager.Application.Monuments.Extensions;
using Monuments.Manager.Application.Monuments.Models;
using Monuments.Manager.Domain.Entities;
using Monuments.Manager.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Monuments.Queries
{
    public class GetMonumentsQueryHandler : IRequestHandler<GetMonumentsQuery, ICollection<MonumentPreviewDto>>
    {
        private readonly MonumentsDbContext _dbContext;

        public GetMonumentsQueryHandler(MonumentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<MonumentPreviewDto>> Handle(GetMonumentsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<MonumentEntity> monuments = _dbContext.Monuments
                .Include(s => s.Address)
                .Include(s => s.User);

            if (!string.IsNullOrEmpty(request.Filter))
            {
                monuments = monuments.Where(s =>
                            EF.Functions.Like(s.Name, $"{request.Filter}%") ||
                            EF.Functions.Like(s.Address.Area, $"{request.Filter}%") ||
                            EF.Functions.Like(s.Address.City, $"{request.Filter}%") ||
                            EF.Functions.Like(s.Address.Commune, $"{request.Filter}%") ||
                            EF.Functions.Like(s.Address.District, $"{request.Filter}%") ||
                            EF.Functions.Like(s.Address.Province, $"{request.Filter}%") ||
                            EF.Functions.Like(s.Address.Street, $"{request.Filter}%") ||
                            EF.Functions.Like(s.FormOfProtection, $"{request.Filter}%"));
            }

            if(request.DescSortOrder)
            {
                monuments = monuments.OrderByDescending(s => s.Name);
            }
            else
            {
                monuments = monuments.OrderBy(s => s.Name);
            }

            var result = await monuments
                .Skip(request.PageSize * request.PageNumber)
                .Take(request.PageSize)
                .Select(s => s.ToPreviewDto(s.Pictures.Select(d => new PictureEntity()
                                                                   {
                                                                       Id = d.Id,
                                                                       Small = d.Small,
                                                                       Description = d.Description
                                                                   }).FirstOrDefault()))
                .ToListAsync();

            return result;
        }
    }
}
