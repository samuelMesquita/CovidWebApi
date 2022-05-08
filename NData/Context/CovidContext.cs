using Business.Entidade;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class CovidContext : DbContext
    {
        public CovidContext(DbContextOptions<CovidContext> options) : base(options)
        {
        }

        public DbSet<Covid> Covid { get; set; }
        public DbSet<DataAtual> DataAtual { get; set; }
    }
}
