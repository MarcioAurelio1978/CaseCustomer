using AutoMapper;
using CaseCustomer.Domain.Entities;
using CaseCustomer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseCustomer.Application.DTOs;
using CaseCustomer.Application.Interfaces;

namespace CaseCustomer.Application.Services
{
    public class ClienteService : IClienteService
    {
        private IClienteRepository _clienteRepository;

        private readonly IMapper _mapper;
        public ClienteService(IMapper mapper, IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository ??
                 throw new ArgumentNullException(nameof(clienteRepository));

            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDTO>> GetClientes()
        {
            var clienteEntity = await _clienteRepository.GetClientesAsync();
            return _mapper.Map<IEnumerable<ClienteDTO>>(clienteEntity);
        }

        public async Task<ClienteDTO> GetById(int? id)
        {
            var clienteEntity = await _clienteRepository.GetByIdAsync(id);
            return _mapper.Map<ClienteDTO>(clienteEntity);
        }

        public async Task Add(ClienteDTO documentoDto)
        {
            var clienteEntity = _mapper.Map<Cliente>(documentoDto);
            await _clienteRepository.CreateAsync(clienteEntity);
        }

        public async Task Update(ClienteDTO clienteDto)
        {

            var clienteEntity = _mapper.Map<Cliente>(clienteDto);
            await _clienteRepository.UpdateAsync(clienteEntity);
        }

        public async Task Remove(int? id)
        {
            var clienteEntity = _clienteRepository.GetByIdAsync(id).Result;
            await _clienteRepository.RemoveAsync(clienteEntity);
        }       
    }
}
