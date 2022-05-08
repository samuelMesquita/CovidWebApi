using System;

namespace CovidWebApi.Model
{
    public class CovidBrasilModel
    {
        Guid Id { get; set; }
        public string Country { get; set; }
        public int Cases { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}
