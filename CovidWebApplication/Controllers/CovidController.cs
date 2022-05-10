using CovidWebApplication.Models;
using CovidWebApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CovidWebApplication.Controllers
{
    [Route("")]
    public class CovidWebController : MainController
    {
        private readonly ICovidHttpService _covidHttpService;

        public CovidWebController(ICovidHttpService covidHttpService)
        {
            _covidHttpService = covidHttpService;
        }

        public async Task<ActionResult<IEnumerable<CovidViewModel>>> Index()
        {
            var response = await _covidHttpService.PegarMediaCovid();
            return View(response);
        }
    }
}
