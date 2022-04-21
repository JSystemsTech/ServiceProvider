using ServiceProvider.Configuration;
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
        => Collection.GetSetting<string>(key);

        protected override IDictionary<string, object> GetConfigurationSource()
        => ConfigurationManager.AppSettings.ToDataDictionary();
    }
}
