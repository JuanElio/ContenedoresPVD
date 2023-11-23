using System.Collections.Generic;
using System.Threading.Tasks;
using App.ModelDto.DTOs;

namespace App.Application.Interfaces
{
	public interface ITipoDocumentalService 
	{
		//public Task<TipodocumentalDTO> ObtenerPorClave(int param);
		//public Task<TipodocumentalDTO> ObtenerPorGuid(string guid);
		public Task<List<TipoDocumentalDTO>> Listar();
		//public Task<int> Agregar(TipodocumentalDTO param);
		//public Task Actualizar(TipodocumentalDTO param);
		//public Task Eliminar(int param);
	}
}
