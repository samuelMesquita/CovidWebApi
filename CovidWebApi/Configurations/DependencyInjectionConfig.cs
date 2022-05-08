using Business.Inteface;
using Data.Context;
using Microsoft.Extensions.DependencyInjection;
using Business.Services;
using Business.Interface;
using Data.Repository;
using Microsoft.AspNetCore.Http;
using NSE.WebApp.MVC.Services;

namespace CovidWebApi.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDataAtualServices, DataAtualServices>();
            services.AddScoped<DataAtualIRepository, DataAtualRepository>();
            services.AddScoped<ICovidServices, CovidServices>();
            services.AddScoped<CovidIRepository, CovidRepository>();
            services.AddHttpClient<IHttpCovidService, HttpCovidService>();

            return services;
        }
    }
}
