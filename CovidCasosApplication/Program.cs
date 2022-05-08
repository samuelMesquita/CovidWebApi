using Business.Inteface;
using Business.Interface;
using Business.Services;
using Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CovidCasosApplication
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDataAtualServices, DataAtualServices>();
            services.AddScoped<DataAtualIRepository, DataAtualRepository>();
            services.AddScoped<ICovidServices, CovidServices>();
            services.AddScoped<CovidIRepository, CovidRepository>();
        }
    }
}
