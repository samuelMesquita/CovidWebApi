using Business.Entidade;
using Business.Interface;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class DataAtualRepository : Repository<DataAtual>, DataAtualIRepository
    {
        public DataAtualRepository(CovidContext db) : base(db)
        {}

        public async Task<bool> SelecionarDataPorData(DataAtual dataAtual)
        {
            var obj = await Db.DataAtual
                  .Where(p => p.Data == dataAtual.Data)
                  .Select(p => p)
                  .FirstOrDefaultAsync();

            if (obj != null) return true;

            return false;
        }
    }
}
