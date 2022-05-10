using CovidWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidWebApplication.Services
{
    public interface ICovidHttpService
    {
        Task<IEnumerable<CovidViewModel>> PegarMediaCovid();
    }
}
