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
    public class GetStreetsQueryHandler : BaseDictionaryQuery<GetStreetsQuery>
    {
        public GetStreetsQueryHandler(IDictionaryProvider dictionaryProvider, MonumentsDbContext dbContext) : base(dictionaryProvider, dbContext)
        {
        }

        protected override async Task<ICollection<DictionaryValueDto>> GetValuesFromDatabaseAsync(GetStreetsQuery request, MonumentsDbContext context)
        {
            var streets = await context.Streets
                .Include(s => s.City)
                    .ThenInclude(s => s.Commune)
                        .ThenInclude(s => s.District)
                            .ThenInclude(s => s.Province)
                .Where(s => s.City.Name == request.City)
                .Where(s => s.City.Commune.Name == request.Commune)
                .Where(s => s.City.Commune.District.Name == request.District)
                .Where(s => s.City.Commune.District.Province.Name == request.Province)
                .Select(s => new DictionaryValueDto() { Name = s.Name })
                .ToListAsync();

            return streets;
        }

        protected override async Task<ICollection<DictionaryValueDto>> GetValuesFromProviderAsync(GetStreetsQuery request, IDictionaryProvider provider)
        {
            var streets = await provider.GetStreetsAsync(new City()
            {
                Province = request.Province,
                District = request.District,
                Commune = request.Commune,
                Name = request.City
            });

            return streets.Select(s => new DictionaryValueDto() { Name = s.Name }).ToList();
        }

        protected override async Task InsertProviderValuesIntoDatabaseAsync(GetStreetsQuery request, ICollection<DictionaryValueDto> providerValues, MonumentsDbContext dbContext)
        {
            var cityEntity = await dbContext.Provinces
                .Include(s => s.Districts)
                    .ThenInclude(s => s.Communes)
                        .ThenInclude(s => s.Cities)
                .Where(s => s.Name == request.Province)
                .SelectMany(s => s.Districts.Where(d => d.Name == request.District))
                .SelectMany(s => s.Communes.Where(d => d.Name == request.Commune))
                .SelectMany(s => s.Cities.Where(d =>d.Name == request.City))
                .FirstOrDefaultAsync();

            if(cityEntity is null)
            {
                throw new MonumentsManagerAppException(ExceptionType.DictionaryParentValueNotFound, $"Parent value for DictionaryValueDto not exists. Details: {request}");
            }

            foreach(var providerValue in providerValues.Where(s => !cityEntity.Streets.Any(d => d.Name == s.Name)))
            {
                cityEntity.Streets.Add(new StreetEntity() { Name = providerValue.Name });
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
