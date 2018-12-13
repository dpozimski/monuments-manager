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
    public class GetMonumentsQueryHandler : IRequestHandler<GetMonumentsQuery, ICollection<MonumentDto>>
    {
        private readonly MonumentsDbContext _dbContext;
        private readonly IImageFactory _thumbnailImageFactory;

        public GetMonumentsQueryHandler(MonumentsDbContext dbContext,
                                        IImageFactory thumbnailImageFactory)
        {
            _dbContext = dbContext;
            _thumbnailImageFactory = thumbnailImageFactory;
        }

        public async Task<ICollection<MonumentDto>> Handle(GetMonumentsQuery request, CancellationToken cancellationToken)
        {
            var monuments = _dbContext.Monuments
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
                .Skip(request.PageSize * (request.PageNumber - 1))
                .Take(request.PageSize)
                .OrderBy(s => s.Name)
                .Select(s => new MonumentDto()
                {
                    Id = s.Id,
                    ConstructionDate = s.ConstructionDate,
                    Name = s.Name,
                    OwnerId = s.UserId,
                    OwnerName = s.User.Email,
                    Picture = s.Pictures.Count > 0 ? _thumbnailImageFactory.CreateThumbnail(s.Pictures.FirstOrDefault().Data) : null,
                    Address = s.Address.ToDto(),
                    ModifiedBy = s.ModifiedBy,
                    ModifiedDate = s.ModifiedDate
                });

            if (request.DescSortOrder)
            {
                monuments = monuments.OrderByDescending(s => s.Name);
            }

            return monuments.ToList();
        }
    }
}
