using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CovidWebApi.Model;
using Microsoft.Extensions.Options;

namespace NSE.WebApp.MVC.Services
{
    public class HttpCovidService : Service, IHttpCovidService
    {
        private readonly HttpClient _httpClient;

        public HttpCovidService(HttpClient httpClient,
            IOptions<AppSettings> url)
        {
            httpClient.BaseAddress = new Uri(url.Value.CovidHttp);

            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CovidBrasilModel>> ObterCovidCasos(string data)
        {
            string datainicio = CalcularSeisMesesAtras(data);

            data = ConvertData(data);

            var response = await _httpClient.GetAsync($"from={datainicio}&to={data}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<IEnumerable<CovidBrasilModel>>(response);
        }

        private string ConvertData(string data)
        {
            return data;
        }

        private string CalcularSeisMesesAtras(string dataAtual)
        {
            string mesesAtras = "";
            return mesesAtras;
        }
    }
}