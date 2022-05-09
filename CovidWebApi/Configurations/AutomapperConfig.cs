using AutoMapper;
using Business.Entidade;
using CovidWebApi.Model;

namespace CovidWebApi.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<CovidBrasilModel, Covid>().ReverseMap();
        }
    }
}