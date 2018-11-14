using Monuments.Manager.Application.Dictionary.Providers.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Dictionary.Providers
{
    public interface IDictionaryProvider
    {
        Task<IEnumerable<Province>> GetProvincesAsync();
        Task<IEnumerable<District>> GetDistrictsAsync(Province province);
        Task<IEnumerable<Commune>> GetCommunesAsync(District district);
        Task<IEnumerable<City>> GetCitiesAsync(Commune commune);
        Task<IEnumerable<Street>> GetStreetsAsync(City city);
    }
}
