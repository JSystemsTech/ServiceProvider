using ServiceProvider.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Configuration;

namespace UnitTests.Services
{
    public interface ITestService
    {
        string GetToken();
    }
    internal class TestService: Service,ITestService
    {
        private ISaml2TokenSettings Saml2TokenSettings => Services.Get<ISaml2TokenSettings>();
        public string GetToken()
        {
            return $"{Saml2TokenSettings.Namespace}{Saml2TokenSettings.Issuer}{Saml2TokenSettings.SubjectName}";
        }
    }
}
