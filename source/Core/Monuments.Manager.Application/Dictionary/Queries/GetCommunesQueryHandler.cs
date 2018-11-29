using MediatR;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Application.Dictionary.Models;
using Monuments.Manager.Application.Dictionary.Providers;
using Monuments.Manager.Application.Dictionary.Providers.Contract;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Domain.Entities;
using Monuments.Manager.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Dictionary.Queries
{
    public class GetCommunesQueryHandler : BaseDictionaryQuery<GetCommunesQuery>
    {
        public GetCommunesQueryHandler(IDictionaryProvider dictionaryProvider, MonumentsDbContext dbContext) : base(dictionaryProvider, dbContext)
        {
        }

        protected override async Task<ICollection<DictionaryValueDto>> GetValuesFromDatabaseAsync(GetCommunesQuery request, MonumentsDbContext context)
        {
            var communes = await context.Communes
                .Include(s => s.District)
                    .ThenInclude(s => s.Province)
                .Where(s => s.District.Name == request.District)
                .Where(s => s.District.Province.Name == request.Province)
                .Select(s => new DictionaryValueDto() { Name = s.Name })
                .ToListAsync();

            return communes;
        }

        protected override async Task<ICollection<DictionaryValueDto>> GetValuesFromProviderAsync(GetCommunesQuery request, IDictionaryProvider provider)
        {
            var communes = await provider.GetCommunesAsync(new District()
            {
                Province = request.Province,
                Name = request.District
            });

            return communes.Select(s => new DictionaryValueDto() { Name = s.Name }).ToList();
        }

        protected override async Task InsertProviderValuesIntoDatabaseAsync(GetCommunesQuery request, ICollection<DictionaryValueDto> providerValues, MonumentsDbContext dbContext)
        {
            var districtEntity = await dbContext.Provinces
                .Include(s => s.Districts)
                .Where(s => s.Name == request.Province)
                .SelectMany(s => s.Districts.Where(d => d.Name == request.District))
                .FirstOrDefaultAsync();

            if(districtEntity is null)
            {
                throw new MonumentsManagerAppException(ExceptionType.DictionaryParentValueNotFound, $"Parent value for GetCommunesQuery not exists. Details: {request}");
            }

            foreach(var providerValue in providerValues.Where(s => !districtEntity.Communes.Any(d => d.Name == s.Name)))
            {
                districtEntity.Communes.Add(new CommuneEntity() { Name = providerValue.Name });
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
