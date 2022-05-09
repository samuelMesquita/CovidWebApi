using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidWebApi.Model
{
    public class MediaMovelModel
    {
        public string Pais { get; set; }
        public List<CovidBrasilModel> covidBrasilModels { get; set; }
    }
}
