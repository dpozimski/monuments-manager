using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Monuments.Manager.Dictionary.Providers.Teryt.WebService;

namespace Monuments.Manager.Application.Dictionary.Providers.Teryt.Client
{
    public class FakeWcfClient : IWcfClient
    {
        public FakeWcfClient(ITerytWs1 channel)
        {
        }

        public Task<PobierzListeMiejscowosciWGminieResponse> GetCitiesAsync(string provinceName, string districtName, string communeName)
        {
            return Task.FromResult(new PobierzListeMiejscowosciWGminieResponse() { PobierzListeMiejscowosciWGminieResult = new List<Miejscowosc>() });
        }

        public Task<PobierzListeGminResponse> GetCommunesAsync(string provinceName, string districtName)
        {
            return Task.FromResult(new PobierzListeGminResponse() { PobierzListeGminResult = new List<JednostkaTerytorialna>() });
        }

        public Task<PobierzListePowiatowResponse> GetDistrictsAsync(string provinceName)
        {
            return Task.FromResult(new PobierzListePowiatowResponse() { PobierzListePowiatowResult = new List<JednostkaTerytorialna>() });
        }

        public Task<PobierzListeWojewodztwResponse> GetProvincesAsync()
        {
            return Task.FromResult(new PobierzListeWojewodztwResponse() { PobierzListeWojewodztwResult = new List<JednostkaTerytorialna>() });
        }

        public Task<PobierzListeUlicDlaMiejscowosciResponse> GetStreetsAsync(string provinceName, string districtName, string communeName, string cityName)
        {
            return Task.FromResult(new PobierzListeUlicDlaMiejscowosciResponse() { PobierzListeUlicDlaMiejscowosciResult = new List<UlicaDrzewo>() });
        }
    }
}
