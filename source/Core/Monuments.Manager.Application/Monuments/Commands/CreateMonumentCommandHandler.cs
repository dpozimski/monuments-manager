using MediatR;
using Monuments.Manager.Application.Infrastructure;
using Monuments.Manager.Common;
using Monuments.Manager.Domain.Entities;
using Monuments.Manager.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Monuments.Commands
{
    public class CreateMonumentCommandHandler : IRequestHandler<CreateMonumentCommand, int>
    {
        private readonly MonumentsDbContext _dbContext;
        private readonly IApplicationContext _context;
        private readonly IImageFactory _imageFactory;

        public CreateMonumentCommandHandler(MonumentsDbContext dbContext,
                                            IApplicationContext context,
                                            IImageFactory imageFactory)
        {
            _dbContext = dbContext;
            _context = context;
            _imageFactory = imageFactory;
        }

        public async Task<int> Handle(CreateMonumentCommand request, CancellationToken cancellationToken)
        {
            var monumentEntity = new MonumentEntity()
            {
                UserId = _context.UserId,
                FormOfProtection = request.FormOfProtection,
                ConstructionDate = request.ConstructionDate,
                Name = request.Name,
                Pictures = request.Pictures.Select(s => new PictureEntity()
                {
                    Data = _imageFactory.Decode(s.Data)
                }).ToList(),
                Address = new AddressEntity()
                {
                    Area = request.Address.Area,
                    City = request.Address.City,
                    Commune = request.Address.Commune,
                    District = request.Address.District,
                    Province = request.Address.Province,
                    Street = request.Address.Street,
                    StreetNumber = request.Address.StreetNumber
                }
            };

            var result = await _dbContext.Monuments.AddAsync(monumentEntity, cancellationToken);

            await _dbContext.SaveChangesAsync();

            return result.Entity.Id;
        }
    }
}
