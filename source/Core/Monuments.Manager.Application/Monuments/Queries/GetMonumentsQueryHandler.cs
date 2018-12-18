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
    public class GetMonumentsQueryHandler : IRequestHandler<GetMonumentsQuery, ICollection<MonumentPreviewDto>>
    {
        private readonly MonumentsDbContext _dbContext;

        public GetMonumentsQueryHandler(MonumentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<ICollection<MonumentPreviewDto>> Handle(GetMonumentsQuery request, CancellationToken cancellationToken)
        {
            var monuments = _dbContext.Monuments
                .Include(s => s.User)
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
                .Skip(request.PageSize * (request.PageNumber - 1))
                .Take(request.PageSize)
                .OrderBy(s => s.Name)
                .Select(s => s.ToPreviewDto(s.Pictures.FirstOrDefault()));

            if (request.DescSortOrder)
            {
                monuments = monuments.OrderByDescending(s => s.Name);
            }

            return Task.FromResult<ICollection<MonumentPreviewDto>>(monuments.ToList());
        }
    }
}
