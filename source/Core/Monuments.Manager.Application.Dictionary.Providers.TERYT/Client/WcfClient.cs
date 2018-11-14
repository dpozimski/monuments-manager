using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Monumets.Manager.Application.Dictionary.Providers.Teryt;

namespace Monuments.Manager.Application.Dictionary.Providers.Teryt.Client
{
    public class WcfClient : IWcfClient
    {
        private readonly ITerytWs1 _terytWs1;

        public WcfClient(ITerytWs1 terytWs1)
        {
            _terytWs1 = terytWs1;
        }

        public async Task<PobierzListeMiejscowosciWGminieResponse> GetCitiesAsync(string provinceName, string districtName, string communeName)
        {
            var request = new PobierzListeMiejscowosciWGminieRequest()
            {
                Wojewodztwo = provinceName,
                Powiat = districtName,
                Gmina = communeName,
                DataStanu = DateTime.Now
            };

            return await _terytWs1.PobierzListeMiejscowosciWGminieAsync(request);
        }

        public async Task<PobierzListeGminResponse> GetCommunesAsync(string provinceName, string districtName)
        {
            var request = new PobierzListeGminRequest()
            {
                Woj = provinceName,
                Pow = districtName,
                DataStanu = DateTime.Now
            };

            return await _terytWs1.PobierzListeGminAsync(request);
        }

        public async Task<PobierzListePowiatowResponse> GetDistrictsAsync(string provinceName)
        {
            var request = new PobierzListePowiatowRequest()
            {
                Woj = provinceName,
                DataStanu = DateTime.Now
            };

            return await _terytWs1.PobierzListePowiatowAsync(request);
        }

        public async Task<PobierzListeWojewodztwResponse> GetProvincesAsync()
        {
            var request = new PobierzListeWojewodztwRequest()
            {
                DataStanu = DateTime.Now
            };

            return await _terytWs1.PobierzListeWojewodztwAsync(request);
        }

        public async Task<PobierzListeUlicDlaMiejscowosciResponse> GetStreetsAsync(string provinceName, string districtName, string communeName, string cityName)
        {
            var request = new PobierzListeUlicDlaMiejscowosciRequest()
            {
                woj = provinceName,
                pow = districtName,
                gmi = communeName,
                msc = cityName,
                czyWersjaUrzedowa = true,
                DataStanu = DateTime.Now,
                czyWersjaAdresowa = false,
            };

            return await _terytWs1.PobierzListeUlicDlaMiejscowosciAsync(request);
        }
    }
}
