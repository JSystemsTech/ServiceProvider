using ServiceProvider.Configuration;
using ServiceProvider.ServiceProvider;
using ServiceProvider.Web;
using System.Configuration;
using System.Web;

namespace ServiceProviderShared
{
    public sealed class ServiceManager
    {
        public static IServices Services => HttpContext.Current.ApplicationInstance is IMvcServiceApplication app ? app.Services : null;
        public static T GetService<T>() => Services is IServices services ? Services.Get<T>(): default;
        public static ConnectionStringSettings GetConnectionString(string key) => Services is IServices services ? services.GetConnectionString(key) : default;
    }
}
