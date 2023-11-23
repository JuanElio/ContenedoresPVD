using System.Collections.Generic;
using System.Threading.Tasks;
using App.ModelDto.DTOs;

namespace App.Application.Interfaces
{
	public interface ITipoDispositivoService 
	{
		//public Task<TipodispositivoDTO> ObtenerPorClave(int param);
		//public Task<TipodispositivoDTO> ObtenerPorGuid(string guid);
		public Task<List<TipoDispositivoDTO>> Listar();
		//public Task<int> Agregar(TipodispositivoDTO param);
		//public Task Actualizar(TipodispositivoDTO param);
		//public Task Eliminar(int param);
	}
}
