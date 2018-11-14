using Monumets.Manager.Application.Dictionary.Providers.Teryt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monuments.Manager.Application.Dictionary.Providers.Teryt.Client
{
    public interface IWcfClientScope : IDisposable
    {
        IWcfClient Client { get; }
    }
}
