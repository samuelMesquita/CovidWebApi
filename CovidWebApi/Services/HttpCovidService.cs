using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CovidWebApi.Model;
using Microsoft.Extensions.Options;
using NSE.WebApp.MVC.Services;

namespace Extensions.Services
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

        public async Task<IEnumerable<CovidBrasilModel>> ObterCovidCasos(DateTime data, string datainicio)
        {
            if (String.IsNullOrEmpty(datainicio))
            {
                datainicio = CalcularSeisMesesAtras(data);
            }
            else
            {
                datainicio = ConvertData(datainicio);
            }

            var dataFim = ConvertData(data.ToString());

            var response = await _httpClient.GetAsync($"live?from={datainicio}&to={dataFim}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<IEnumerable<CovidBrasilModel>>(response);
        }

        private string ConvertData(string data)
        {
            var dataSeparada = data.Split(" ");

            var dataNova = dataSeparada[0].Split("/");

            return $"{dataNova[2]}-{dataNova[1]}-{dataNova[0]}T{dataSeparada[1]}Z";
        }

        private string CalcularSeisMesesAtras(DateTime dataAtual)
        {
            var seisMesesAtras = dataAtual.AddMonths(-6);

            return ConvertData(seisMesesAtras.ToString());
        }
    }
}