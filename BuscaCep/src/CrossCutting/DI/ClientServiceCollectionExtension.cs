using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Infra.Client;
using Domain.Client;
using Application.Service;
using Application.Interface;

namespace CrossCutting.DI
{
    public static class ClientServiceCollectionExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            #region SERVICE
            services.AddTransient<ICepService, CepService>();
            #endregion 

            #region CLIENT
            services.AddSingleton<ICepClient, CepClient>();
            services.AddHttpClient();
            #endregion

            return services;
        }
    }
}
