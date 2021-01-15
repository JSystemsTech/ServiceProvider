using ServiceProvider.ServiceProvider;

namespace ServiceProvider.Web
{

    public interface IMvcServiceApplication
    {
        IServices Services { get; }
    }
    public abstract class MvcServiceApplication : System.Web.HttpApplication, IMvcServiceApplication
    {
        private ServiceCollection ServiceCollection { get; set; }
        private IServices GetServiceCollection()
        {
            if(ServiceCollection == null)
            {
                ServiceCollection = new ServiceCollection(ConfigureServices);
            }
            return ServiceCollection;
        }
        public IServices Services { get => GetServiceCollection(); }
        public virtual void ConfigureServices(IServiceCollection serviceBuilder) { }
    }
}
