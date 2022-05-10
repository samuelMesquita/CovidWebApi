using System;
using System.Collections.Generic;

namespace CovidWebApplication.Models
{
    public class CovidViewModel
    {
        public string Pais { get; set; }
        public int MediaMovel { get; set; }
        public DateTime inicioSemana { get; set; }
        public DateTime fimSemana { get; set; }
        public List<CovidBrasilModel> covidBrasilModels { get; set; }
    }
    public class CovidBrasilModel
    {
        public string Country { get; set; }
        public int Cases { get; set; }
        public DateTime Date { get; set; }
    }
}