using System.Collections.Generic;

namespace Monuments.Manager.Application.Dictionary.Providers.Contract
{
    public class Commune
    {
        public string Name { get; set; }
        public List<City> Cities { get; private set; }

        public Commune()
        {
            Cities = new List<City>();
        }
    }
}