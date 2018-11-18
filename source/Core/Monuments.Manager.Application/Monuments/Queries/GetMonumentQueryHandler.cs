using MediatR;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Application.Exceptions;
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
    public class GetMonumentQueryHandler : IRequestHandler<GetMonumentQuery, MonumentDto>
    {
        private readonly MonumentsDbContext _dbContext;

        public GetMonumentQueryHandler(MonumentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MonumentDto> Handle(GetMonumentQuery request, CancellationToken cancellationToken)
        {
            var monumentEntity = await _dbContext.Monuments
                .Include(s => s.Address)
                .Include(s => s.Pictures)
                .FirstOrDefaultAsync(s => s.Id == request.MonumentId);

            if(monumentEntity is null)
            {
                throw new EntityNotFoundException<MonumentEntity>(request.MonumentId);
            }

            var pictureEntity = monumentEntity.Pictures.FirstOrDefault();

            return new MonumentDto()
            {
                Id = monumentEntity.Id,
                ConstructionDate = monumentEntity.ConstructionDate,
                Name = monumentEntity.Name,
                OwnerId = monumentEntity.UserId,
                OwnerName = monumentEntity.User.Username,
                Picture = pictureEntity.Data,
                Address = new AddressDto()
                {
                    Area = monumentEntity.Address.Area,
                    City = monumentEntity.Address.City,
                    Commune = monumentEntity.Address.Commune,
                    District = monumentEntity.Address.District,
                    Province = monumentEntity.Address.Province,
                    Street = monumentEntity.Address.Street,
                    StreetNumber = monumentEntity.Address.StreetNumber
                }
            };
        }
    }
}
