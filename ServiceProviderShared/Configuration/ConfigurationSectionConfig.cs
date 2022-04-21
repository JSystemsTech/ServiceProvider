using ServiceProvider.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;

namespace ServiceProvider.Configuration
{
    public interface IConfiguration
    {
        void InitConfiguation(IServices services);
    }
    public interface IConfigurationSectionConfig
    {
        IDictionary<string, object> Collection { get; }
    }
    public abstract class ConfigurationSectionConfig : IConfigurationSectionConfig, IConfiguration
    {
        public IDictionary<string, object> Collection { get; protected set; }
        protected IServices Services { get; private set; }
        protected virtual IDictionary<string, object> GetConfigurationSource()
        => (ConfigurationManager.GetSection(ConfiguationSection) as NameValueCollection).ToDataDictionary();
        public void InitConfiguation(IServices services)
        {
            Services = services;
            Collection = GetConfigurationSource();
            Init();
        }
        protected virtual void Init() { }
        protected virtual string ConfiguationSection => null;

        public ConfigurationSectionConfig() { }

    }
}
