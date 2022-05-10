using CovidWebApi.Model;
using CovidWebApplication.Models;
using Extensions.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CovidWebApplication.Services
{
    public class CovidHttpService : Service, ICovidHttpService
    {
        private readonly HttpClient _httpClient;

        public CovidHttpService(HttpClient httpClient,
            IOptions<AppSettings> url)
        {
            httpClient.BaseAddress = new Uri(url.Value.CovidWebApi);

            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CovidViewModel>> PegarMediaCovid()
        {
            var response = await _httpClient.GetAsync("covid-casos");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<IEnumerable<CovidViewModel>>(response);
        }
    }
}
