using MediatR;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Domain.Entities;
using Monuments.Manager.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Monuments.Commands
{
    public class UpdateMonumentCommandHandler : IRequestHandler<UpdateMonumentCommand>
    {
        private readonly MonumentsDbContext _dbContext;

        public UpdateMonumentCommandHandler(MonumentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateMonumentCommand request, CancellationToken cancellationToken)
        {
            var monumentEntity = await _dbContext.Monuments
                .Include(s => s.Address)
                .FirstOrDefaultAsync(s => s.Id == request.MonumentId);

            if(monumentEntity is null)
            {
                throw new MonumentsManagerAppException(ExceptionType.EntityNotFound, $"Entity of type MonumentEntity with id {request.MonumentId} does not exists");
            }

            monumentEntity.FormOfProtection = request.FormOfProtection;
            monumentEntity.Name = request.Name;
            monumentEntity.ConstructionDate = request.ConstructionDate;
            monumentEntity.Address = new AddressEntity()
            {
                Area = request.Address.Area,
                City = request.Address.City,
                Commune = request.Address.Commune,
                District = request.Address.District,
                Province = request.Address.Province,
                Street = request.Address.Street,
                StreetNumber = request.Address.StreetNumber
            };

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
