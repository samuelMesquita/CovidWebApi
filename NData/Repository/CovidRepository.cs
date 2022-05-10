using Business.Entidade;
using Business.Interface;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CovidRepository : Repository<Covid>, CovidIRepository
    {
        public CovidRepository(CovidContext db) : base(db)
        {
        }

        public async Task DeleteMenoresDatas(int numeroDeletes)
        {
            var obj = await ObterTodos();

            var ultimasDatas = obj.OrderBy(p=> p.Date).Select(p=> p).Take(numeroDeletes);

            Db.Covid.RemoveRange(ultimasDatas);

            await SaveChanges();
        }

        public async Task IncluirListaCovid(IEnumerable<Covid> covid)
        {
            await Db.AddRangeAsync(covid);

            await SaveChanges();
        }

        public async Task<List<Covid>> ListarCovids()
        {
            return await Db.Covid.OrderByDescending(p => p.Date)
                .Select(p => p)
                .Take(21)
                .ToListAsync();
        }

        public async Task<Covid> ObterMaiorDataCovid()
        {
            return await Db.Covid
                .OrderByDescending(p => p.Date)
                .Select(p => p)
                .FirstOrDefaultAsync();
        }

        public async Task<Covid> ObterPorData(DateTime dataCaso)
        {
            return await Db.Covid
                .Where(p => p.Date == dataCaso)
                .FirstOrDefaultAsync();
        }
    }
}
