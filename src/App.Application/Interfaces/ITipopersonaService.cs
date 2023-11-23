using System.Collections.Generic;
using System.Threading.Tasks;
using App.ModelDto.DTOs;

namespace App.Application.Interfaces
{
	public interface ITipoPersonaService 
	{
		public Task<TipoPersonaDTO> ObtenerPorClave(string param);
		//public Task<TipoPersonaDTO> ObtenerPorGuid(string guid);
		public Task<List<TipoPersonaDTO>> Listar();
		public Task<string> Agregar(TipoPersonaDTO param);
		public Task Actualizar(TipoPersonaDTO param);
		//public Task Eliminar(int param);
	}
}
