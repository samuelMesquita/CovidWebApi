using Business.Entidade;
using Business.Inteface;
using Business.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class DataAtualServices : IDataAtualServices
    {
        private readonly DataAtualIRepository _dataAtualIRepository;

        public DataAtualServices(DataAtualIRepository dataAtualIRepository)
        {
            _dataAtualIRepository = dataAtualIRepository;
        }

        public async Task IncluirDataAtual(DataAtual dataAtual)
        {
            await _dataAtualIRepository.Adicionar(dataAtual);
        }

        public async Task<bool> SelecionarDataporData(DataAtual dateAtual)
        {
            return await _dataAtualIRepository.SelecionarDataPorData(dateAtual);
        }
    }
}
