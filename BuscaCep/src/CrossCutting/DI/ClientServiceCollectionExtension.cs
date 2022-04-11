using Microsoft.Extensions.Configuration;

using Infra.Client;
using Domain.Client;
using Application.Service;
using Application.Interface;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddHttpClient<ICepClient, CepClient>();
            #endregion

            return services;
        }
    }
}
