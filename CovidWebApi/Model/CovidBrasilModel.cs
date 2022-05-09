using System;

namespace CovidWebApi.Model
{
    public class CovidBrasilModel
    {
        int Id { get; set; }
        public string Country { get; set; }
        public int Cases { get; set; }
        public DateTime Date { get; set; }
    }
}
