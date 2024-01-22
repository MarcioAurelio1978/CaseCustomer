using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseCustomer.Domain.Entities;
using CaseCustomer.Domain.Interfaces;
using CaseCustomer.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CaseCustomer.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private ApplicationDbContext _clienteContext;

        public ClienteRepository(ApplicationDbContext context)
        {
            _clienteContext = context;
        }
        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            _clienteContext.Add(cliente);
            await _clienteContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> GetByIdAsync(int? id)
        {
            //return await _clienteContext.Clientes.FindAsync(id);
            return await _clienteContext.Clientes.Include(c => c.Documento)
                   .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await _clienteContext.Clientes.ToListAsync();
        }

        public async Task<Cliente> RemoveAsync(Cliente cliente)
        {
           _clienteContext.Remove(cliente);
            await _clienteContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> UpdateAsync(Cliente cliente)
        {
           _clienteContext.Update(cliente);
            await _clienteContext.SaveChangesAsync();
            return cliente;
        }
    }
}
