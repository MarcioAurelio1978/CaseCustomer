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
    public class DocumentoRepository : IDocumentoRepository
    {
        private ApplicationDbContext _documentoContext;
        public DocumentoRepository(ApplicationDbContext context)
        {
            _documentoContext = context;
        }
        public async Task<Documento> CreateAsync(Documento documento)
        {
            _documentoContext.Add(documento);
            await _documentoContext.SaveChangesAsync();
            return documento;
        }

        public async Task<Documento> GetByIdAsync(int? id)
        {
            return await _documentoContext.Documentos.FindAsync(id);
        }

        public async Task<IEnumerable<Documento>> GetDocumentosAsync()
        {
            try
            {
                var documentos = await _documentoContext.Documentos.ToListAsync();
                return documentos;
            }
            catch (Exception ex)
            {
                var erro = ex.Message;
                var erro2 = ex.InnerException;
                var erro3 = ex.StackTrace;
                throw;
            }
        }

        public async Task<Documento> RemoveAsync(Documento documento)
        {
            _documentoContext.Remove(documento);
            await _documentoContext.SaveChangesAsync();
            return documento;
        }

        public async Task<Documento> UpdateAsync(Documento documento)
        {
            _documentoContext.Update(documento);
            await _documentoContext.SaveChangesAsync();
            return documento;
        }
    }
}
