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
    public class GetProvincesQueryHandler : BaseDictionaryQuery<GetProvincesQuery>
    {
        public GetProvincesQueryHandler(IDictionaryProvider dictionaryProvider, MonumentsDbContext dbContext) : base(dictionaryProvider, dbContext)
        {
        }

        protected override async Task<ICollection<DictionaryValueDto>> GetValuesFromDatabaseAsync(GetProvincesQuery request, MonumentsDbContext context)
        {
            var provinces = await context.Districts
                .Select(s => new DictionaryValueDto() { Name = s.Name })
                .ToListAsync();

            return provinces;
        }

        protected override async Task<ICollection<DictionaryValueDto>> GetValuesFromProviderAsync(GetProvincesQuery request, IDictionaryProvider provider)
        {
            var districts = await provider.GetProvincesAsync();

            return districts.Select(s => new DictionaryValueDto() { Name = s.Name }).ToList();
        }

        protected override async Task InsertProviderValuesIntoDatabaseAsync(GetProvincesQuery request, ICollection<DictionaryValueDto> providerValues, MonumentsDbContext dbContext)
        {
            var provinces = await dbContext.Provinces.ToListAsync();

            if (provinces.Count > 0)
                return;

            foreach(var providerValue in providerValues)
            {
                dbContext.Provinces.Add(new ProvinceEntity() { Name = providerValue.Name });
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
