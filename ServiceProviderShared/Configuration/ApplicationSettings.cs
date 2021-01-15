using ServiceProvider.ServiceProvider;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace ServiceProvider.Configuration
{
    public interface IApplicationSettings : IConfigurationSectionConfig
    {
        string GetSetting(string key);
    }
    public class ApplicationSettings: ConfigurationSectionConfig,IApplicationSettings, ISpecialConfiguration
    {
        public string GetSetting(string key)
        {
            throw new NotImplementedException();
        }

        protected override IDictionary<string, string> GetConfigurationSource()
        {
            return ConfigurationManager.AppSettings.AllKeys.ToDictionary(key => key, key => ConfigurationManager.AppSettings[key]);
        }
    }
}
