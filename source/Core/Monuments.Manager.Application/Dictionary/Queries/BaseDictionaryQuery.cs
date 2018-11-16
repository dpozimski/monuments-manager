using MediatR;
using Monuments.Manager.Application.Dictionary.Models;
using Monuments.Manager.Application.Dictionary.Providers;
using Monuments.Manager.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Dictionary.Queries
{
    public abstract class BaseDictionaryQuery<TRequest> : IRequestHandler<TRequest, ICollection<DictionaryValueDto>> 
        where TRequest : IRequest<ICollection<DictionaryValueDto>>
    {
        private readonly IDictionaryProvider _dictionaryProvider;
        private readonly MonumentsDbContext _dbContext;

        public BaseDictionaryQuery(IDictionaryProvider dictionaryProvider,
                                   MonumentsDbContext dbContext)
        {
            _dictionaryProvider = dictionaryProvider;
            _dbContext = dbContext;
        }

        public async Task<ICollection<DictionaryValueDto>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var dbValues = await GetValuesFromDatabaseAsync(request, _dbContext);

            if(dbValues.Count > 0)
            {
                return dbValues;
            }
            else
            {
                var providerValues = await GetValuesFromProviderAsync(request, _dictionaryProvider);
                await InsertProviderValuesIntoDatabaseAsync(request, providerValues, _dbContext);

                return dbValues;
            }
        }

        protected abstract Task InsertProviderValuesIntoDatabaseAsync(TRequest request, ICollection<DictionaryValueDto> providerValues, MonumentsDbContext dbContext);
        protected abstract Task<ICollection<DictionaryValueDto>> GetValuesFromProviderAsync(TRequest request, IDictionaryProvider provider);
        protected abstract Task<ICollection<DictionaryValueDto>> GetValuesFromDatabaseAsync(TRequest request, MonumentsDbContext context);
    }
}
