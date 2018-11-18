using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Monuments.Manager.Application.Dictionary.Providers;
using Monuments.Manager.Application.Dictionary.Providers.Teryt;
using Monuments.Manager.Application.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monuments.Manager.Application.Dictionary.Factories
{
    public class DictionaryProviderFactory : IDictionaryProviderFactory
    {
        private readonly IOptions<DictionaryProvidersOptions> _options;
        private readonly IServiceProvider _serviceProvider;

        public DictionaryProviderFactory(IOptions<DictionaryProvidersOptions> options,
                                         IServiceProvider serviceProvider)
        {
            _options = options;
            _serviceProvider = serviceProvider;
        }

        public IDictionaryProvider Create()
        {
            var currentProvider = _options.Value.CurrentProvider;

            switch(_options.Value.CurrentProvider)
            {
                case DictionaryProviderCode.Teryt:
                    return _serviceProvider.GetService<TerytDictionaryProvider>();
                default:
                    throw new InvalidOperationException($"Cannot create dictionary provider for {currentProvider}");
            }
        }
    }
}
