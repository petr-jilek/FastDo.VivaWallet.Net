using FastDo.VivaWallet.Net.Services;

namespace FastDo.VivaWallet.Net.Extensions
{
    public static class ServiceInjectionExtensions
    {
        public static IServiceCollection AddVivaWalletService(this IServiceCollection services, VivaWalletServiceSettings settings)
        {
            if (settings.IsAnyStringNullOrEmpty())
                throw new ArgumentNullException(typeof(VivaWalletServiceSettings).Name);

            services.AddSingleton(settings);

            services.AddScoped<IVivaWalletService, VivaWalletService>();
            return services;
        }

        public static IServiceCollection AddVivaWalletService(this IServiceCollection services, IConfiguration configurations)
        {
            var settings = new VivaWalletServiceSettings();
            configurations.GetSection(typeof(VivaWalletServiceSettings).Name).Bind(settings);

            if (settings.IsAnyStringNullOrEmpty())
                throw new ArgumentNullException(typeof(VivaWalletServiceSettings).Name);

            services.AddSingleton(settings);

            services.AddScoped<IVivaWalletService, VivaWalletService>();
            return services;
        }
    }
}
