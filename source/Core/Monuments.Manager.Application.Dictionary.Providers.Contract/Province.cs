using System;
using System.Collections.Generic;

namespace Monuments.Manager.Application.Dictionary.Providers.Contract
{
    public class Province
    {
        public string Name { get; set; }
        public List<District> Districts { get; private set; }

        public Province()
        {
            Districts = new List<District>();
        }
    }
}
