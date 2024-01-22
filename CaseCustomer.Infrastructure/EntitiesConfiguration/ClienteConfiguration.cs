using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseCustomer.Domain.Entities;

namespace CaseCustomer.Infrastructure.EntitiesConfiguration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();        
            builder.Property(p => p.DataNascimento).IsRequired();
            builder.Property(p => p.Endereco).HasMaxLength(200).IsRequired();
            builder.Property(p => p.DataCadastro).IsRequired();
            builder.Property(p => p.ClienteAtivo).HasMaxLength(3); 

            builder.HasOne(e => e.Documento).WithMany(e => e.Clientes)
                .HasForeignKey(e => e.DocumentoId);
        }
    }
}
