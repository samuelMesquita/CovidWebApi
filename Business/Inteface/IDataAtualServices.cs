using Business.Entidade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Inteface
{
    public interface IDataAtualServices : IDisposable
    {
        Task IncluirDataAtual(DataAtual dataAtual);

        Task<bool> SelecionarDataporData(string dateAtual);
    }
}
