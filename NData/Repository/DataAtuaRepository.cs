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

        public async Task<DataAtual> SelecionarDataPorData(DataAtual dataAtual)
        {
            return await Db.DataAtual
                  .Select(p => p)
                  .FirstOrDefaultAsync();
        }
    }
}
