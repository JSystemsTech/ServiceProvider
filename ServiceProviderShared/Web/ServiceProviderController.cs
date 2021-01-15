using ServiceProvider.ServiceProvider;
using System.Web.Mvc;

namespace ServiceProvider.Web
{
    public abstract class ServiceProviderController:Controller
    {
        protected IServices Services => HttpContext.ApplicationInstance is IMvcServiceApplication app ? app.Services : null;
    }
}
