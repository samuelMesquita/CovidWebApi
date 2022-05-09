using Business.Entidade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Inteface
{
    public interface IDataAtualServices 
    {
        Task IncluirDataAtual(DataAtual dataAtual);

        Task<bool> SelecionarDataporData(DataAtual dateAtual);
    }
}
