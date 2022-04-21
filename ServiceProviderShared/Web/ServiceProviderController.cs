using System.Web.Mvc;

namespace ServiceProvider.Web
{
    public abstract class ServiceProviderController:Controller
    {
        protected IServices Services => ServiceConfig.Services;
        protected T GetService<T>() => Services.Get<T>();
    }
}
