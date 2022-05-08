using Business.Entidade;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
