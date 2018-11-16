using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Monuments.Manager.Application.Dictionary.Providers.Contract;
using Monuments.Manager.Application.Dictionary.Providers.Teryt.Client;
using Monuments.Manager.Application.Dictionary.Providers.Teryt.Mapping;

namespace Monuments.Manager.Application.Dictionary.Providers.Teryt
{
    public class TerytDictionaryProvider : IDictionaryProvider
    {
        private readonly IWcfClientScopeFactory _clientScopeFactory;
        private readonly IContractMapper _contractMapper;

        public TerytDictionaryProvider(IWcfClientScopeFactory clientScopeFactory,
                                       IContractMapper contractMapper)
        {
            _clientScopeFactory = clientScopeFactory;
            _contractMapper = contractMapper;
        }

        public async Task<IEnumerable<City>> GetCitiesAsync(Commune commune)
        {
            using (var scope = _clientScopeFactory.CreateScope())
            {
                var cities = await scope.Client.GetCitiesAsync(commune.Province, commune.District, commune.Name);

                return _contractMapper.Create(cities);
            }
        }

        public async Task<IEnumerable<Commune>> GetCommunesAsync(District district)
        {
            using (var scope = _clientScopeFactory.CreateScope())
            {
                var communes = await scope.Client.GetCommunesAsync(district.Province, district.Name);

                return _contractMapper.Create(communes);
            }
        }

        public async Task<IEnumerable<District>> GetDistrictsAsync(Province province)
        {
            using (var scope = _clientScopeFactory.CreateScope())
            {
                var districts = await scope.Client.GetDistrictsAsync(province.Name);

                return _contractMapper.Create(districts);
            }
        }

        public async Task<IEnumerable<Province>> GetProvincesAsync()
        {
            using (var scope = _clientScopeFactory.CreateScope())
            {
                var provinces = await scope.Client.GetProvincesAsync();

                return _contractMapper.Create(provinces);
            }
        }

        public async Task<IEnumerable<Street>> GetStreetsAsync(City city)
        {
            using (var scope = _clientScopeFactory.CreateScope())
            {
                var streets = await scope.Client.GetStreetsAsync(city.Province, city.District, city.Commune, city.Name);

                return _contractMapper.Create(streets);
            }
        }
    }
}
