using System;

namespace ServiceProvider
{
    public class ServiceConfig
    {
        private static ServiceCollection ServiceCollection = new ServiceCollection();
        public static IServices Services => ServiceCollection;
        public static void RegisterServices(Action<IServiceCollection> handler)
        {
            handler(ServiceCollection);
        }        
    }
}
