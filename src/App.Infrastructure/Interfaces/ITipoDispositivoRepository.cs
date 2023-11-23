using System.Collections.Generic;
using System.Threading.Tasks;
using App.ModelDto.DTOs;

namespace App.Infrastructure.Interfaces
{
	public interface ITipoDispositivoRepository 
	{
		//public Task<TipoDispositivoDTO> ObtenerPorClave(int param);
		//public Task<TipoDispositivoDTO> ObtenerPorGuid(string guid);
		public Task<List<TipoDispositivoDTO>> Listar();
		//public Task<int> Agregar(TipoDispositivoDTO param);
		//public Task Actualizar(TipoDispositivoDTO param);
		//public Task Eliminar(int param);
	}
}
