using Business.Entidade;
using Business.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CovidServices : ICovidServices
    {
        private readonly CovidIRepository _covidIRepository;

        public CovidServices(CovidIRepository covidIRepository)
        {
            _covidIRepository = covidIRepository;
        }

        public Task DeleteCovid(int id)
        {
            return _covidIRepository.Remover(id);
        }

        public async Task IncluirCovid(Covid covid)
        {
            await _covidIRepository.Adicionar(covid);
        }

        public async Task<List<Covid>> ListarCovids()
        {
            return await _covidIRepository.ObterTodos();
        }

        public async Task<Covid> ObterPorData(DateTime dataCaso)
        {
            return await _covidIRepository.ObterPorData(dataCaso);
        }

        public void Dispose()
        {
            _covidIRepository?.Dispose();
        }

        public async Task IncluirListaCovid(IEnumerable<Covid> covid)
        {
            await _covidIRepository.IncluirListaCovid(covid);
        }

        public async Task<Covid> ObterMaiorDataCovid()
        {
            return await _covidIRepository.ObterMaiorDataCovid();
        }

        public async Task DeleteMenoresDatas(int numeroDeletes)
        {
            await _covidIRepository.DeleteMenoresDatas(numeroDeletes);
        }
    }
}
