//using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseCustomer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaseCustomer.Infrastructure.Context 
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
        { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Documento> Documentos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext)
                .Assembly);
        }
    }
}
