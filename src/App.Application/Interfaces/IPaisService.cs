using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Entities;
using App.ModelDto.DTOs;

namespace App.Application.Interfaces
{
	public interface IPaisService 
	{
        //public Task<PaisDTO> ObtenerPorClave(int param);
        //public Task<PaisDTO> ObtenerPorGuid(string guid);

        //public Task<int> Agregar(PaisDTO param);
        //public Task Actualizar(PaisDTO param);
        //public Task Eliminar(int param);
        public Task<List<PaisDTO>> Listar();
        public Task<PaisDTO> ObtenerPorCodigo(string codigo);
    }
}
