using AutoMapper;
using CaseCustomer.Application.DTOs;
using CaseCustomer.Application.Interfaces;
using CaseCustomer.Domain.Entities;
using CaseCustomer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseCustomer.Application.Services
{
    public class DocumentoService : IDocumentoService
    {
        private IDocumentoRepository _documentoRepository;

        private readonly IMapper _mapper;
        public DocumentoService(IMapper mapper, IDocumentoRepository documentoRepository)
        {
            _documentoRepository = documentoRepository ??
                 throw new ArgumentNullException(nameof(documentoRepository));

            _mapper = mapper;
        }

        public async Task<IEnumerable<DocumentoDTO>> GetDocumentos()
        {
            var documentoEntity = await _documentoRepository.GetDocumentosAsync();
            return _mapper.Map<IEnumerable<DocumentoDTO>>(documentoEntity);
        }

        public async Task<DocumentoDTO> GetById(int? id)
        {
            var documentoEntity = await _documentoRepository.GetByIdAsync(id);
            return _mapper.Map<DocumentoDTO>(documentoEntity);
        }

        public async Task Add(DocumentoDTO documentoDto)
        {
            var documentoEntity = _mapper.Map<Documento>(documentoDto);
            await _documentoRepository.CreateAsync(documentoEntity);
        }

        public async Task Update(DocumentoDTO documentoDto)
        {

            var documentoEntity = _mapper.Map<Documento>(documentoDto);
            await _documentoRepository.UpdateAsync(documentoEntity);
        }

        public async Task Remove(int? id)
        {
            var documentoEntity = _documentoRepository.GetByIdAsync(id).Result;
            await _documentoRepository.RemoveAsync(documentoEntity);
        }

    }
}
