﻿using Monuments.Manager.Application.Dictionary.Providers.Contract;
using Monumets.Manager.Application.Dictionary.Providers.Teryt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Dictionary.Providers.Teryt.Mapping
{
    public interface IContractMapper
    {
        IEnumerable<Province> Create(PobierzListeWojewodztwResponse response);
        IEnumerable<District> Create(PobierzListePowiatowResponse response);
        IEnumerable<Commune> Create(PobierzListeGminResponse response);
        IEnumerable<City> Create(PobierzListeMiejscowosciWGminieResponse response);
        IEnumerable<Street> Create(PobierzListeUlicDlaMiejscowosciResponse response);
    }
}