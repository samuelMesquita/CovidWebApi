using System;
using CovidWebApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CovidWebApplication.Configuration

{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {

            #region HttpServices

            services.AddHttpClient<ICovidHttpService, CovidHttpService>();

            #endregion
        }
    }
}