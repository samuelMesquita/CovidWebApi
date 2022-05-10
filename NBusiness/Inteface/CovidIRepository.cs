using Business.Entidade;
using DevIO.Business.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface CovidIRepository : IRepository<Covid>
    {
        Task<Covid> ObterPorData(DateTime dataCaso);

        Task IncluirListaCovid(IEnumerable<Covid> covid);

        Task<List<Covid>> ListarCovids();

        Task<Covid> ObterMaiorDataCovid();
        Task DeleteMenoresDatas(int numeroDeletes);
    }
}
