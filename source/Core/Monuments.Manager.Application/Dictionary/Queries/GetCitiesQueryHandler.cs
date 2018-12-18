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
    public class GetCitiesQueryHandler : BaseDictionaryQuery<GetCitiesQuery>
    {
        public GetCitiesQueryHandler(IDictionaryProvider dictionaryProvider, MonumentsDbContext dbContext) : base(dictionaryProvider, dbContext)
        {
        }

        protected override async Task<ICollection<DictionaryValueDto>> GetValuesFromDatabaseAsync(GetCitiesQuery request, MonumentsDbContext context)
        {
            var cities = await context.Cities
                .Include(s => s.Commune)
                    .ThenInclude(s => s.District)
                        .ThenInclude(s => s.Province)
                .Where(s => s.Commune.Name == request.Commune)
                .Where(s => s.Commune.District.Name == request.District)
                .Where(s => s.Commune.District.Province.Name == request.Province)
                .Select(s => new DictionaryValueDto() { Name = s.Name })
                .ToListAsync();

            return cities;
        }

        protected override async Task<ICollection<DictionaryValueDto>> GetValuesFromProviderAsync(GetCitiesQuery request, IDictionaryProvider provider)
        {
            var cities = await provider.GetCitiesAsync(new Commune()
            {
                Province = request.Province,
                District = request.District,
                Name = request.Commune
            });

            return cities.Select(s => new DictionaryValueDto() { Name = s.Name }).ToList();
        }

        protected override async Task InsertProviderValuesIntoDatabaseAsync(GetCitiesQuery request, ICollection<DictionaryValueDto> providerValues, MonumentsDbContext dbContext)
        {
            var communeEntity = await dbContext.Provinces
                .Include(s => s.Districts)
                    .ThenInclude(s => s.Communes)
                .Where(s => s.Name == request.Province)
                .SelectMany(s => s.Districts.Where(d => d.Name == request.District))
                .SelectMany(s => s.Communes.Where(d => d.Name == request.Commune))
                .FirstOrDefaultAsync();

            if(communeEntity is null)
            {
                return;
            }

            foreach(var providerValue in providerValues.Where(s => !communeEntity.Cities.Any(d => d.Name == s.Name)))
            {
                communeEntity.Cities.Add(new CityEntity() { Name = providerValue.Name });
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
