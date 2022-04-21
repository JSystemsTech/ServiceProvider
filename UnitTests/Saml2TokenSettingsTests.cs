using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Configuration;

namespace UnitTests
{
    [TestClass]
    public class Saml2TokenSettingsTests
    {
        private static IServices Services => ServiceConfig.Services;
        private static ISaml2TokenSettings Saml2TokenSettings => Services.Get<ISaml2TokenSettings>();

        [TestMethod]
        public void HasSaml2TokenSettings()
        {
            Assert.IsNotNull(Saml2TokenSettings, "Saml2TokenSettings is null");
        }
        [TestMethod]
        public void VerifyAudienceUri()
        {
            Assert.AreEqual("https://www.federated.ip.com", Saml2TokenSettings.AudienceUri, "AudienceUri is invalid");
        }
        [TestMethod]
        public void VerifyConfirmationMethod()
        {
            Assert.AreEqual("https://www.federated.ip.com", Saml2TokenSettings.ConfirmationMethod, "ConfirmationMethod is invalid");
        }
        [TestMethod]
        public void VerifyIssuer()
        {
            Assert.AreEqual("FederatedIP", Saml2TokenSettings.Issuer, "Issuer is invalid");
        }
        [TestMethod]
        public void VerifyNamespace()
        {
            Assert.AreEqual("FederatedIP_Authentication", Saml2TokenSettings.Namespace, "Namespace is invalid");
        }
        [TestMethod]
        public void VerifySubjectName()
        {
            Assert.AreEqual("FederatedIP_Authentication_SAML2", Saml2TokenSettings.SubjectName, "SubjectName is invalid");
        }
        [TestMethod]
        public void VerifyValidFor()
        {
            Assert.AreEqual(20, Saml2TokenSettings.ValidFor, "ValidFor is invalid");
        }

        [TestMethod]
        public void VerifyTimeoutWarning()
        {
            Assert.AreEqual(2, Saml2TokenSettings.TimeoutWarning, "TimeoutWarning is invalid");
        }
    }
}
