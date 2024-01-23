using Microsoft.AspNetCore.Mvc;
using System;
using CaseCustomer.Application.DTOs;
using CaseCustomer.Application.Interfaces;
using CaseCustomer.Domain.Entities;


namespace CaseCustomer.API.Controllers
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
       

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;   
        }

        // api/clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
        {
            var clientes = await _clienteService.GetClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}", Name = "GetCliente")]
        public async Task<ActionResult<ClienteDTO>> Get(int id)
        {
            var cliente = await _clienteService.GetById(id);

            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteDTO clienteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _clienteService.Add(clienteDto);

            return new CreatedAtRouteResult("GetCliente",
                new { id = clienteDto.Id }, clienteDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClienteDTO clienteDto)
        {
            if (id != clienteDto.Id)
            {
                return BadRequest();
            }

            await _clienteService.Update(clienteDto);

            return Ok(clienteDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> Delete(int id)
        {
            var clienteDto = await _clienteService.GetById(id);
            if (clienteDto == null)
            {
                return NotFound();
            }
            await _clienteService.Remove(id);
            return Ok(clienteDto);
        }



    }
}
