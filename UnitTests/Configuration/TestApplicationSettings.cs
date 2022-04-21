using ServiceProvider.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Configuration
{
    public enum ApplicationEnvironment
    {
        Localhost,
        Development,
        Evaluation,
        Production
    }
    public interface ITestApplicationSettings
    {
        string ApplicationName { get; }
        ApplicationEnvironment Environment { get; }
        string EnvironmentName { get; }
        bool ShowEnvironmentName { get; }
        IEnumerable<string> Themes { get; }
    }
    internal class TestApplicationSettings: ApplicationSettings, ITestApplicationSettings
    {
        public string ApplicationName { get; private set; }
        public  ApplicationEnvironment Environment { get; private set; }
        public string EnvironmentName =>
            Environment == ApplicationEnvironment.Localhost ? "Localhost" :
            Environment == ApplicationEnvironment.Development ? "Development" :
            Environment == ApplicationEnvironment.Evaluation ? "Evaluation" :
            Environment == ApplicationEnvironment.Production ? "Production" :
            "Unknown";
        public bool ShowEnvironmentName { get; private set; }
        public IEnumerable<string> Themes { get; private set; }
        protected override void Init() {
            ApplicationName = Collection.GetSetting<string>("ApplicationName");
            Environment = Collection.GetSetting<ApplicationEnvironment>("Environment");
            ShowEnvironmentName = Collection.GetSetting("ShowEnvironmentName", true);
            Themes = Collection.GetEnumerableSetting<string>("Themes");
        }
    }
    public interface ISaml2TokenSettings
    {
        string AudienceUri { get; }
        string ConfirmationMethod { get; }
        string Issuer { get; }
        string Namespace { get; }
        string SubjectName { get; }
        int ValidFor { get; }
        int TimeoutWarning { get; }
    }
    internal class Saml2TokenSettings : ConfigurationSectionConfig, ISaml2TokenSettings
    {
        public string AudienceUri { get; private set; }
        public string ConfirmationMethod { get; private set; }
        public string Issuer { get; private set; }
        public string Namespace { get; private set; }
        public string SubjectName { get; private set; }
        public int ValidFor { get; private set; }
        public int TimeoutWarning { get; private set; }        
        protected override string ConfiguationSection => "saml2TokenSettings";
        protected override void Init()
        {
            AudienceUri = Collection.GetSetting<string>("AudienceUri");
            ConfirmationMethod = Collection.GetSetting<string>("ConfirmationMethod");
            Issuer = Collection.GetSetting<string>("Issuer");
            Namespace = Collection.GetSetting<string>("Namespace");
            SubjectName = Collection.GetSetting<string>("SubjectName");
            ValidFor = Collection.GetSetting<int>("ValidFor");
            TimeoutWarning = Collection.GetSetting<int>("TimeoutWarning");
        }
    }
}
