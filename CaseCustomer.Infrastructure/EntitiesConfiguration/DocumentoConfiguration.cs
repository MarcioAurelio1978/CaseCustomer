using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseCustomer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaseCustomer.Infrastructure.EntitiesConfiguration
{
    public class DocumentoConfiguration : IEntityTypeConfiguration<Documento>
    {
        public void Configure(EntityTypeBuilder<Documento> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Numero).HasMaxLength(100).IsRequired();

            builder.HasData(
              new Documento(1, "CPF", "27614673883"),
              new Documento(2, "RG", "290169462")             
            );
        }
    }
}
