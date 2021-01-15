using FederatedIPAuthenticationService.Configuration;
using ServiceProvider.Configuration;
using ServiceProvider.ServiceProvider;

namespace ServiceProvider.Services
{
    public static class ServiceFactory
    {
        public static void AddApplicationSettings<TIApplicationSettings, TApplicationSettings>(this IServiceCollection services)
            where TApplicationSettings : ApplicationSettings, TIApplicationSettings
        {
            services.AddConfiguration<TIApplicationSettings, TApplicationSettings>();
        }
        public static void AddApplicationSettings<TApplicationSettings>(this IServiceCollection services)
            where TApplicationSettings : ApplicationSettings
        {
            services.AddConfiguration<IApplicationSettings, TApplicationSettings>();
        }
        public static void AddApplicationSettings(this IServiceCollection services)
        {
            services.AddConfiguration<IApplicationSettings, ApplicationSettings>();
        }

        public static void AddConnectionStringConfig<TIConnectionStringConfig, TConnectionStringConfig>(this IServiceCollection services)
            where TConnectionStringConfig : ConnectionStringConfig, TIConnectionStringConfig
        {
            services.AddConfiguration<TIConnectionStringConfig, TConnectionStringConfig>();
        }
        public static void AddConnectionStringConfig<TConnectionStringConfig>(this IServiceCollection services)
            where TConnectionStringConfig : ConnectionStringConfig
        {
            services.AddConfiguration<IConnectionStringConfig, TConnectionStringConfig>();
        }
        public static void AddConnectionStringConfig(this IServiceCollection services)
        {
            services.AddConfiguration<IConnectionStringConfig, ConnectionStringConfig>();
        }
    }
}
