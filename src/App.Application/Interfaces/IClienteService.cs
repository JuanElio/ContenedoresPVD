using App.ModelDto.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Interfaces
{
    public interface IClienteService
    {
        public Task<List<ClienteDTO>> Listar();
        public Task<int> Agregar(ClienteDTO param);
    }
}
