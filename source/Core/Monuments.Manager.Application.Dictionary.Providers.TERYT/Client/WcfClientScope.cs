using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace Monuments.Manager.Application.Dictionary.Providers.Teryt.Client
{
    public class WcfClientScope : IWcfClientScope
    {
        private Action _onDispose;

        public IWcfClient Client { get; }

        public WcfClientScope(IWcfClient client, Action onDispose)
        {
            Client = client;
            _onDispose = onDispose;
        }

        
        public void Dispose()
        {
            _onDispose();
        }
    }
}
