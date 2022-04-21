using ServiceProvider.Configuration;
using ServiceProvider.Services;

namespace ServiceProvider
{
    public static class ServiceFactory
    {
        public static void AddConfiguration<TIService, TService>(this IServiceCollection services)
            where TService : class, IConfiguration, TIService
        {
            services.Add<TIService, TService>();
        }
        public static void AddConfiguration<TService>(this IServiceCollection services) 
            where TService : class, IConfiguration
        {
            services.Add<TService>();
        }
        public static void AddService<TService>(this IServiceCollection services)
            where TService : class, IService
        {
            services.Add<TService>();
        }
        public static void AddService<TIService, TService>(this IServiceCollection services)
            where TService : class, IService, TIService
        {
            services.Add<TIService, TService>();
        }
        public static void AddApplicationSettings<TIApplicationSettings, TApplicationSettings>(this IServiceCollection services)
            where TApplicationSettings : ApplicationSettings, TIApplicationSettings
        {
            services.Add<TIApplicationSettings, TApplicationSettings>();
        }
        public static void AddApplicationSettings<TApplicationSettings>(this IServiceCollection services)
            where TApplicationSettings : ApplicationSettings
        {
            services.Add<IApplicationSettings, TApplicationSettings>();
        }
        public static void AddApplicationSettings(this IServiceCollection services)
        {
            services.Add<IApplicationSettings, ApplicationSettings>();
        }

        public static void AddConnectionStringConfig<TIConnectionStringConfig, TConnectionStringConfig>(this IServiceCollection services)
            where TConnectionStringConfig : ConnectionStringConfig, TIConnectionStringConfig
        {
            services.Add<TIConnectionStringConfig, TConnectionStringConfig>();
        }
        public static void AddConnectionStringConfig<TConnectionStringConfig>(this IServiceCollection services)
            where TConnectionStringConfig : ConnectionStringConfig
        {
            services.Add<IConnectionStringConfig, TConnectionStringConfig>();
        }
        public static void AddConnectionStringConfig(this IServiceCollection services)
        {
            services.Add<IConnectionStringConfig, ConnectionStringConfig>();
        }
    }
}
