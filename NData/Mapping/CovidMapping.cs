using Business.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping
{
    public class CovidMapping : IEntityTypeConfiguration<Covid>
    {
        public void Configure(EntityTypeBuilder<Covid> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Cases)
                .IsRequired();

            builder.Property(p=> p.Date)
                .IsRequired();
            builder.Property(p => p.Country)
                .IsRequired();

            builder.ToTable("Covid");
        }
    }
}
