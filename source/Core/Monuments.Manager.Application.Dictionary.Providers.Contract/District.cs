using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Dictionary.Providers.Contract
{
    public class District
    {
        public string Name { get; set; }
        public List<Commune> Communes { get; private set; }

        public District()
        {
            Communes = new List<Commune>();
        }
    }
}
