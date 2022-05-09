using Business.Entidade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ICovidServices: IDisposable
    {
        Task IncluirCovid(Covid covid);
        Task<List<Covid>> ListarCovids();
        Task<Covid> ObterPorData(DateTime dataCaso);
        Task DeleteCovid(int id);
        Task IncluirListaCovid(IEnumerable<Covid> covid);
        Task <Covid>ObterMaiorDataCovid();
        Task DeleteMenoresDatas(int numeroDeletes);
    }
}
