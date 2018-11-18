using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using Microsoft.Extensions.Options;
using Monuments.Manager.Dictionary.Providers.Teryt.WebService;

namespace Monuments.Manager.Application.Dictionary.Providers.Teryt.Client
{
    public class WcfClientScopeFactory : IWcfClientScopeFactory
    {
        private readonly IOptions<TerytConfigurationOptions> _terytConfigurationOptions;

        public WcfClientScopeFactory(IOptions<TerytConfigurationOptions> terytConfigurationOptions)
        {
            _terytConfigurationOptions = terytConfigurationOptions;
        }

        public IWcfClientScope CreateScope()
        {
            var configuration = _terytConfigurationOptions.Value;

            var binding = new CustomBinding();
            binding.Name = "terytBinding";
            binding.Elements.Add(new TextMessageEncodingBindingElement(MessageVersion.None, Encoding.Default));
            binding.Elements.Add(new HttpsTransportBindingElement() { RequireClientCertificate = false });
            
            var endpointAddress = new EndpointAddress(configuration.WebServiceUrl);

            var channelFactory = new ChannelFactory<ITerytWs1>(binding, endpointAddress);

            channelFactory.Credentials.UserName.UserName = configuration.Username;
            channelFactory.Credentials.UserName.Password = configuration.Password;

            var channel = channelFactory.CreateChannel();

            IWcfClient wcfClient = null;

            if (configuration.IsBindingSupportedForNetCore)
                wcfClient = new WcfClient(channel);
            else
                wcfClient = new FakeWcfClient(channel);

            return new WcfClientScope(wcfClient, () => ((IDisposable)channelFactory).Dispose());
        }
    }
}
