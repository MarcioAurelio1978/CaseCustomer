using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseCustomer.Domain.Entities;

namespace CaseCustomer.Domain.Interfaces
{
    public interface IDocumentoRepository
    {
        Task<IEnumerable<Documento>> GetDocumentosAsync();
        Task<Documento> GetByIdAsync(int? id);
        Task<Documento> CreateAsync(Documento documento);
        Task<Documento> UpdateAsync(Documento documento);
        Task<Documento> RemoveAsync(Documento documento);
    }
}
