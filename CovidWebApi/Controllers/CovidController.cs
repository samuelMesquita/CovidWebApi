using AutoMapper;
using Business.Entidade;
using Business.Inteface;
using Business.Interface;
using CovidWebApi.Model;
using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CovidWebApi.Controllers
{
    [Route("")]
    [Route("api/[controller]")]
    [ApiController]
    public class CovidController : MainController
    {

        private readonly IHttpCovidService _httpCovidService;
        private readonly IDataAtualServices _dataAtualServices;
        private readonly ICovidServices _covidServices;
        private readonly IMapper _mapper;

        public CovidController(IHttpCovidService httpCovidService,
                                IDataAtualServices dataAtualServices,
                                ICovidServices covidServices,
                                IMapper mapper)
        {
            _httpCovidService = httpCovidService;
            _dataAtualServices = dataAtualServices;
            _covidServices = covidServices;
            _mapper = mapper;
        }
        public async Task<IActionResult> index()
        {
            var dataAtual = new DataAtual { Data = DateTime.Now };

            if(await _dataAtualServices.SelecionarDataporData())return Ok();

            var responseData = await _covidServices.ObterMaiorDataCovid();

            string datainicio = "";

           if(responseData != null)
                datainicio = responseData.Date.ToString();

            var response = await _httpCovidService.ObterCovidCasos(dataAtual.Data, datainicio);

            await _covidServices.IncluirListaCovid(_mapper.Map<IEnumerable<Covid>>(response));

            if(datainicio != "")
            {
                await _covidServices.DeleteMenoresDatas(response.Count());
            }
            await _dataAtualServices.IncluirDataAtual(dataAtual);

            return Ok();
        }

        [HttpGet("covid-casos")]
        public async Task<IActionResult> MediaModel()
        {
            var response = await _covidServices.ListarCovids();

            if (response == null) AdicionarErroProcessamento("O banco covid esta vazio");

            response.OrderBy(p => p.Date);

            var MediaMovel = CalcularMediaModel(response);

            if (!OperacaoValida()) return CustomResponse();

            return Ok(MediaMovel);
        }

        private List<MediaMovelModel> CalcularMediaModel(List<Covid> covidListDesc)
        {
            var mediaMovel = new List<MediaMovelModel>();
            var covidMedia = new List<CovidBrasilModel>();
            int Ni = 0;
            int i = 0;
            foreach(var covid in covidListDesc)
            {

                covidMedia.Add(_mapper.Map<CovidBrasilModel>(covid));

                if (i == 6 || covidListDesc.Count() == Ni)
                {
                    var obj = covidMedia.ToList();
                    mediaMovel.Add(
                    new MediaMovelModel
                    {
                        Pais = "Brasil",
                        MediaMovel = obj.Select(p => p.Cases).Sum() / 7,
                        covidBrasilModels = obj
                    });

                    covidMedia.Clear();
                    i = 0;
                }

                Ni++;
                i++;
            }

            return mediaMovel;
        }
    }
}
