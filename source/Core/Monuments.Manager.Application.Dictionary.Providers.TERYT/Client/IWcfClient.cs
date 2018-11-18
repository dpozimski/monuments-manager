using Monuments.Manager.Dictionary.Providers.Teryt.WebService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Dictionary.Providers.Teryt.Client
{
    public interface IWcfClient
    {
        Task<PobierzListeWojewodztwResponse> GetProvincesAsync();
        Task<PobierzListePowiatowResponse> GetDistrictsAsync(string provinceName);
        Task<PobierzListeGminResponse> GetCommunesAsync(string provinceName, string districtName);
        Task<PobierzListeMiejscowosciWGminieResponse> GetCitiesAsync(string provinceName, string districtName, string communeName);
        Task<PobierzListeUlicDlaMiejscowosciResponse> GetStreetsAsync(string provinceName, string districtName, string communeName, string cityName);
    }
}
