using System.Collections.Generic;
using System.Threading.Tasks;
using CovidWebApi.Model;

namespace NSE.WebApp.MVC.Services
{
    public interface IHttpCovidService
    {
        Task<IEnumerable<CovidBrasilModel>> ObterCovidCasos(string data);
    }
}