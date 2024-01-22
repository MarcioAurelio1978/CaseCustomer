using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseCustomer.Application.DTOs;

namespace CaseCustomer.Application.Interfaces
{
    public interface IDocumentoService
    {
        Task<IEnumerable<DocumentoDTO>> GetDocumentos();
        Task<DocumentoDTO> GetById(int? id);
        Task Add(DocumentoDTO documentoDto);
        Task Update(DocumentoDTO documentoDto);
        Task Remove(int? id);
    }
}
