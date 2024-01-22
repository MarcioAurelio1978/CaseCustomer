using Microsoft.AspNetCore.Mvc;
using System;
using CaseCustomer.Application.DTOs;
using CaseCustomer.Application.Interfaces;
using CaseCustomer.Domain.Entities;

namespace CaseCustomer.API.Controllers
{

    [Route("api/v1/[Controller]")]
    [ApiController]
    public class DocumentoController : Controller
    {
        private readonly IDocumentoService _documentoService;
       
        public DocumentoController(IDocumentoService documentoService)
        {
            _documentoService = documentoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentoDTO>>> Get()
        {
            try
            {
                var documentos = await _documentoService.GetDocumentos();
                return Ok(documentos);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("{id}", Name = "GetDocumentos")]
        public async Task<ActionResult<Documento>> Get(int id)
        {
            var documento = await _documentoService.GetById(id);

            if (documento == null)
            {
                return NotFound();
            }
            return Ok(documento);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DocumentoDTO documentoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _documentoService.Add(documentoDto);

            return new CreatedAtRouteResult("GetDocumento",
                new { id = documentoDto.Id }, documentoDto);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] DocumentoDTO documentoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != documentoDto.Id)
            {
                return BadRequest();
            }
            await _documentoService.Update(documentoDto);
            return Ok(documentoDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Documento>> Delete(int id)
        {
            var documentoDto = await _documentoService.GetById(id);
            if (documentoDto == null)
            {
                return NotFound();
            }
            await _documentoService.Remove(id);
            return Ok(documentoDto);
        }
    }
}
