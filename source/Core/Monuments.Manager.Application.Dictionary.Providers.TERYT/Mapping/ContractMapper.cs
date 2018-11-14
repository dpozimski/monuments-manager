using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monuments.Manager.Application.Dictionary.Providers.Contract;
using Monumets.Manager.Application.Dictionary.Providers.Teryt;

namespace Monuments.Manager.Application.Dictionary.Providers.Teryt.Mapping
{
    public class ContractMapper : IContractMapper
    {
        public IEnumerable<Province> Create(PobierzListeWojewodztwResponse response)
        {
            return response.PobierzListeWojewodztwResult.Select(s => new Province()
            {
                Name = s.NAZWA
            });
        }

        public IEnumerable<District> Create(PobierzListePowiatowResponse response)
        {
            return response.PobierzListePowiatowResult.Select(s => new District()
            {
                Name = s.NAZWA,
                ProvinceName = s.WOJ
            });
        }

        public IEnumerable<Commune> Create(PobierzListeGminResponse response)
        {
            return response.PobierzListeGminResult.Select(s => new Commune()
            {
                Name = s.NAZWA,
                ProvinceName = s.WOJ,
                DistrictName = s.POW
            });
        }

        public IEnumerable<City> Create(PobierzListeMiejscowosciWGminieResponse response)
        {
            return response.PobierzListeMiejscowosciWGminieResult.Select(s => new City()
            {
                Name = s.Nazwa,
                ProvinceName = s.Wojewodztwo,
                DistrictName = s.Powiat,
                CommuneName = s.Gmina
            });
        }

        public IEnumerable<Street> Create(PobierzListeUlicDlaMiejscowosciResponse response)
        {
            return response.PobierzListeUlicDlaMiejscowosciResult.Select(s => new Street()
            {
                Name = s.Nazwa1,
                ProvinceName = s.Woj,
                DistrictName = s.Pow,
                CommuneName = s.Gmi,
                CityName = s.IdentyfikatorMiejscowosci
            });
        }
    }
}
