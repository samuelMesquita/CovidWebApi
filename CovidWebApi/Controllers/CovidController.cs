using Business.Entidade;
using Business.Inteface;
using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Services;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CovidWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CovidController : ControllerBase
    {

        private readonly IHttpCovidService _httpCovidService;
        private readonly IDataAtualServices _dataAtualServices;

        public CovidController(IHttpCovidService httpCovidService,
                                IDataAtualServices dataAtualServices)
        {
            _httpCovidService = httpCovidService;
            _dataAtualServices = dataAtualServices;
        }
        public async Task<bool> index()
        {
            var dataAtual = new DataAtual { Data = DateTime.Today.ToString() };

            var a = await _dataAtualServices.SelecionarDataporData(dataAtual);

            await _dataAtualServices.IncluirDataAtual(dataAtual);

            await _httpCovidService.ObterCovidCasos(dataAtual.ToString());

            return true;

        }

        [HttpGet("covid-casos")]
        public async Task<IActionResult> Get(string data = null)
        {
            if (String.IsNullOrEmpty(data)) return BadRequest();

            return Ok(await _httpCovidService.ObterCovidCasos(data));
        }
    }
}
