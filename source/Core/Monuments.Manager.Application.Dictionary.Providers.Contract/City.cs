using System.Collections.Generic;

namespace Monuments.Manager.Application.Dictionary.Providers.Contract
{
    public class City
    {
        public string Name { get; set; }
        public List<Street> Streets { get; private set; }

        public City()
        {
            Streets = new List<Street>();
        }
    }
}