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
        private readonly CityConfiguration _cityConfiguration;
        private readonly CommuneConfiguration _communeConfiguration;
        private readonly DistrictConfiguration _districtConfiguration;
        private readonly MonumentConfiguration _monumentConfiguration;
        private readonly PictureConfiguration _pictureConfiguration;
        private readonly ProvinceConfiguration _provinceConfiguration;
        private readonly StreetConfiguration _streetConfiguration;
        private readonly UserConfiguration _userConfiguration;

        public ConfigurationBuilder(AddressConfiguration addressConfiguration,
                                    CityConfiguration cityConfiguration,
                                    CommuneConfiguration communeConfiguration,
                                    DistrictConfiguration districtConfiguration,
                                    MonumentConfiguration monumentConfiguration,
                                    PictureConfiguration pictureConfiguration,
                                    ProvinceConfiguration provinceConfiguration,
                                    StreetConfiguration streetConfiguration,
                                    UserConfiguration userConfiguration)
        {
            _addressConfiguration = addressConfiguration;
            _cityConfiguration = cityConfiguration;
            _communeConfiguration = communeConfiguration;
            _districtConfiguration = districtConfiguration;
            _monumentConfiguration = monumentConfiguration;
            _pictureConfiguration = pictureConfiguration;
            _provinceConfiguration = provinceConfiguration;
            _streetConfiguration = streetConfiguration;
            _userConfiguration = userConfiguration;
        }

        public void ApplyConfiguration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(_addressConfiguration);
            builder.ApplyConfiguration(_cityConfiguration);
            builder.ApplyConfiguration(_communeConfiguration);
            builder.ApplyConfiguration(_districtConfiguration);
            builder.ApplyConfiguration(_monumentConfiguration);
            builder.ApplyConfiguration(_pictureConfiguration);
            builder.ApplyConfiguration(_provinceConfiguration);
            builder.ApplyConfiguration(_streetConfiguration);
            builder.ApplyConfiguration(_userConfiguration);
        }
    }
}
