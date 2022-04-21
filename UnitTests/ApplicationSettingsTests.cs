using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceProvider;
using System;
using System.Linq;
using UnitTests.Configuration;

namespace UnitTests
{
    [TestClass]
    public class ApplicationSettingsTests
    {
        private static IServices Services => ServiceConfig.Services;
        private static ITestApplicationSettings ApplicationSettings => Services.Get<ITestApplicationSettings>();
        
        [TestMethod]
        public void HasApplicationSettings()
        {
            Assert.IsNotNull(ApplicationSettings, "ApplicationSettings is null");
        }
        [TestMethod]
        public void VerifyApplicationName()
        {
            Assert.AreEqual("My ASP.NET Application", ApplicationSettings.ApplicationName, "ApplicationName is invalid");
        }

        [TestMethod]
        public void VerifyEnvironment()
        {
            Assert.AreEqual(ApplicationEnvironment.Localhost, ApplicationSettings.Environment, "Environment is invalid");
        }
        [TestMethod]
        public void VerifyEnvironmentName()
        {
            Assert.AreEqual("Localhost", ApplicationSettings.EnvironmentName, "EnvironmentName is invalid");
        }
        [TestMethod]
        public void VerifyShowEnvironmentName()
        {
            Assert.IsTrue(ApplicationSettings.ShowEnvironmentName, "ShowEnvironmentName is invalid");
        }
        [TestMethod]
        public void VerifyThemes()
        {
            Assert.IsNotNull(ApplicationSettings.Themes, "Themes is null");
            Assert.AreEqual(3, ApplicationSettings.Themes.Count(), "Themes has no elements");
            Assert.AreEqual("default", ApplicationSettings.Themes.ElementAt(0), "Default Theme is invalid");
            Assert.AreEqual("mainTheme", ApplicationSettings.Themes.ElementAt(1), "Main Theme is invalid");
            Assert.AreEqual("darkTheme", ApplicationSettings.Themes.ElementAt(2), "Dark Theme is invalid");
        }
    }
}
