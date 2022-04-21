using ServiceProvider.Configuration;
using ServiceProvider.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace ServiceProvider
{
    public interface IServiceCollection
    {
        void Add<TService>()
            where TService : class;
        void Add<TIService, TService>()
            where TService : class, TIService;
    }
    public interface IServices
    {
        T Get<T>();
        ConnectionStringSettings GetConnectionString(string key);
    }
    
    
    public interface ISpecialConfiguration: IConfiguration { }
    internal class ServiceCollection : IServiceCollection, IServices
    {
        private Dictionary<(Type type, Type alias), object> Services { get; set; }

        public void Add<TService>()
            where TService : class
        => Add<TService, TService>();
        public void Add<TIService, TService>()
            where TService : class, TIService
        {            
            if (!Services.Keys.Any(k => k.type == typeof(TService) || k.alias == typeof(TIService)))
            {
                Services.Add((typeof(TService), typeof(TIService)), null);
            }
        }
        public T Get<T>()
        {
            if (Services.Keys.Any(k=>k.type == typeof(T) || k.alias == typeof(T)))
            {
                var key = Services.Keys.FirstOrDefault(k => k.type == typeof(T) || k.alias == typeof(T));
                Services.TryGetValue(key, out object service);
                if (service == null)
                {
                    T newServiceInstance = (T)Activator.CreateInstance(key.type);
                    if (newServiceInstance is ISpecialConfiguration iSpecialConfiguration)
                    {
                        iSpecialConfiguration.InitConfiguation(this);
                    }
                    else if (newServiceInstance is IService iService)
                    {
                        iService.InitService(this);
                    }
                    else if (newServiceInstance is IConfiguration iConfiguration)
                    {
                        iConfiguration.InitConfiguation(this);
                    }
                    Services[key] = newServiceInstance;
                    return newServiceInstance;
                }
                else if(service is T serviceInstance)
                {
                    return serviceInstance;
                }
            }
            return default(T);
        }

        public ServiceCollection()
        {
            Services = new Dictionary<(Type type, Type alias), object>();
        }


        public ConnectionStringSettings GetConnectionString(string key) 
            => Get<IConnectionStringConfig>() is IConnectionStringConfig config ? config.GetConnectionString(key): default;
    }
}
