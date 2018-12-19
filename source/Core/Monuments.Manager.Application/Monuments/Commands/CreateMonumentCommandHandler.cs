using MediatR;
using Monuments.Manager.Application.Monuments.Extensions;
using Monuments.Manager.Application.Monuments.Models;
using Monuments.Manager.Common;
using Monuments.Manager.Domain.Entities;
using Monuments.Manager.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Monuments.Commands
{
    public class CreateMonumentCommandHandler : IRequestHandler<CreateMonumentCommand, MonumentPreviewDto>
    {
        private readonly MonumentsDbContext _dbContext;
        private readonly IApplicationContext _context;

        public CreateMonumentCommandHandler(MonumentsDbContext dbContext,
                                            IApplicationContext context)
        {
            _dbContext = dbContext;
            _context = context;
        }

        public async Task<MonumentPreviewDto> Handle(CreateMonumentCommand request, CancellationToken cancellationToken)
        {
            var monumentEntity = new MonumentEntity()
            {
                UserId = _context.UserId,
                FormOfProtection = request.FormOfProtection,
                ConstructionDate = request.ConstructionDate,
                Name = request.Name,
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

            return result.Entity.ToPreviewDto(new PictureEntity());
        }
    }
}
