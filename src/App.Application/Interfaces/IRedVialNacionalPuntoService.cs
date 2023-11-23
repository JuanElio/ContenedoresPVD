using System.Collections.Generic;
using System.Threading.Tasks;
using App.ModelDto.DTOs;

namespace App.Application.Interfaces
{
	public interface IRedVialNacionalPuntoService 
	{
		//public Task<RedVialNacionalPuntoDTO> ObtenerPorClave(int param);
		//public Task<RedVialNacionalPuntoDTO> ObtenerPorGuid(string guid);
		public Task<List<RedVialNacionalPuntoDTO>> Listar();
        public Task<List<RedVialNacionalPuntoDTO>> Listar(string ruta);
        public Task<int> Agregar(RedVialNacionalPuntoDTO param);
		//public Task Actualizar(RedVialNacionalPuntoDTO param);
		//public Task Eliminar(int param);
	}
}
