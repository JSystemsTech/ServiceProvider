using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Configuration;
using UnitTests.Services;

namespace UnitTests
{
    [TestClass]
    public class Startup
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            // Initalization code goes here
            ServiceConfig.RegisterServices(services => {
                services.AddApplicationSettings<ITestApplicationSettings, TestApplicationSettings>();
                services.AddConfiguration<ISaml2TokenSettings, Saml2TokenSettings>();
                services.AddService<ITestService, TestService>();
            });
        }
    }
}
