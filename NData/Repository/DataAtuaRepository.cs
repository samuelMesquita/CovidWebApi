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

        public async Task<bool> SelecionarDataPorData()
        {
            var obj = await Db.DataAtual
                .OrderByDescending(p => p.Data)
                .Select(p => p.Data)
                .FirstOrDefaultAsync();

            if (obj == DateTime.Now.Date) return true;

            return false;
        }
    }
}
