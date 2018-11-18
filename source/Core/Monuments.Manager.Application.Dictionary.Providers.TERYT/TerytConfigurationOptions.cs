using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Dictionary.Providers.Teryt
{
    public class TerytConfigurationOptions
    {
        public string WebServiceUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsBindingSupportedForNetCore { get; set; }
    }
}
