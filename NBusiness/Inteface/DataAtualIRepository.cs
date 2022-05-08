using Business.Entidade;
using DevIO.Business.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface DataAtualIRepository : IRepository<DataAtual>
    {
        Task<DataAtual> SelecionarDataPorData(DataAtual dataAtual);
    }
}
