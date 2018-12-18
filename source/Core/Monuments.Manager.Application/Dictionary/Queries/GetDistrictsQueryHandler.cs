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
    public class GetDistrictsQueryHandler : BaseDictionaryQuery<GetDistrictsQuery>
    {
        public GetDistrictsQueryHandler(IDictionaryProvider dictionaryProvider, MonumentsDbContext dbContext) : base(dictionaryProvider, dbContext)
        {
        }

        protected override async Task<ICollection<DictionaryValueDto>> GetValuesFromDatabaseAsync(GetDistrictsQuery request, MonumentsDbContext context)
        {
            var districts = await context.Districts
                .Include(s => s.Province)
                .Where(s => s.Province.Name == request.Province)
                .Select(s => new DictionaryValueDto() { Name = s.Name })
                .ToListAsync();

            return districts;
        }

        protected override async Task<ICollection<DictionaryValueDto>> GetValuesFromProviderAsync(GetDistrictsQuery request, IDictionaryProvider provider)
        {
            var districts = await provider.GetDistrictsAsync(new Province()
            {
                Name = request.Province
            });

            return districts.Select(s => new DictionaryValueDto() { Name = s.Name }).ToList();
        }

        protected override async Task InsertProviderValuesIntoDatabaseAsync(GetDistrictsQuery request, ICollection<DictionaryValueDto> providerValues, MonumentsDbContext dbContext)
        {
            var provinceEntity = await dbContext.Provinces
                .Where(s => s.Name == request.Province)
                .FirstOrDefaultAsync();

            if(provinceEntity is null)
            {
                return;
            }

            foreach(var providerValue in providerValues.Where(s => !provinceEntity.Districts.Any(d => d.Name == s.Name)))
            {
                provinceEntity.Districts.Add(new DistrictEntity() { Name = providerValue.Name });
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
