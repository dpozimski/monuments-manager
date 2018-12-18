using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Persistence.Configurations;

namespace Monuments.Manager.Persistence
{
    public class ConfigurationBuilder : IConfigurationBuilder
    {
        private readonly AddressConfiguration _addressConfiguration;
        private readonly MonumentConfiguration _monumentConfiguration;
        private readonly PictureConfiguration _pictureConfiguration;
        private readonly UserConfiguration _userConfiguration;

        public ConfigurationBuilder(AddressConfiguration addressConfiguration,
                                    MonumentConfiguration monumentConfiguration,
                                    PictureConfiguration pictureConfiguration,
                                    UserConfiguration userConfiguration)
        {
            _addressConfiguration = addressConfiguration;
            _monumentConfiguration = monumentConfiguration;
            _pictureConfiguration = pictureConfiguration;
            _userConfiguration = userConfiguration;
        }

        public void ApplyConfiguration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(_addressConfiguration);
            builder.ApplyConfiguration(_monumentConfiguration);
            builder.ApplyConfiguration(_pictureConfiguration);
            builder.ApplyConfiguration(_userConfiguration);
        }
    }
}
