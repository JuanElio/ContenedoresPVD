using App.Application.Interfaces;
using App.Domain.Entities;
using App.Infrastructure.Interfaces;
using App.Infrastructure.Repository;
using App.ModelDto.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<int> Agregar(ClienteDTO param)
        {
            var item = _mapper.Map<Cliente>(param);
           
            return await _clienteRepository.Agregar(item);
        }

        public async Task Actualizar(ClienteDTO param)
        {
            var item = _mapper.Map<Cliente>(param);

            await _clienteRepository.Actualizar(item);
        }

        public async Task<ClienteDTO> ObtenerPorClave(int param)
        {
            var item = await _clienteRepository.ObtenerPorClave(param);

            var result = _mapper.Map<ClienteDTO>(item);

            return result;

        }


        public async Task<List<ClienteDTO>> Listar()
        {
            var lista = await _clienteRepository.Listar();
            
            var result = _mapper.Map<List<ClienteDTO>>(lista);

            return result;

        }
    }
}
