using Business.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping
{
    class DataAtualMapping : IEntityTypeConfiguration<DataAtual>
    {
        public void Configure(EntityTypeBuilder<DataAtual> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Data);

            builder.ToTable("DataAtual");
        }
    }
}
