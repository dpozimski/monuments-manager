using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monuments.Manager.Application.Dictionary.Providers.Contract;
using Monuments.Manager.Dictionary.Providers.Teryt.WebService;

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
                Province = s.WOJ
            });
        }

        public IEnumerable<Commune> Create(PobierzListeGminResponse response)
        {
            return response.PobierzListeGminResult.Select(s => new Commune()
            {
                Name = s.NAZWA,
                Province = s.WOJ,
                District = s.POW
            });
        }

        public IEnumerable<City> Create(PobierzListeMiejscowosciWGminieResponse response)
        {
            return response.PobierzListeMiejscowosciWGminieResult.Select(s => new City()
            {
                Name = s.Nazwa,
                Province = s.Wojewodztwo,
                District = s.Powiat,
                Commune = s.Gmina
            });
        }

        public IEnumerable<Street> Create(PobierzListeUlicDlaMiejscowosciResponse response)
        {
            return response.PobierzListeUlicDlaMiejscowosciResult.Select(s => new Street()
            {
                Name = s.Nazwa1,
                Province = s.Woj,
                District = s.Pow,
                Commune = s.Gmi,
                City = s.IdentyfikatorMiejscowosci
            });
        }
    }
}
