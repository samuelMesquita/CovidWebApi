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

        public async Task<Covid> ObterPorData(DateTime dataCaso)
        {
            return await Db.Covid
                .Where(p => p.DataCasos == dataCaso)
                .FirstOrDefaultAsync();
        }
    }
}
