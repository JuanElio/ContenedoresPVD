using System.Collections.Generic;
using System.Threading.Tasks;
using App.ModelDto.DTOs;

namespace App.Application.Interfaces
{
	public interface ITipoInversionService 
	{
		//public Task<TipoinversionDTO> ObtenerPorClave(int param);
		//public Task<TipoinversionDTO> ObtenerPorGuid(string guid);
		public Task<List<TipoInversionDTO>> Listar();
		//public Task<int> Agregar(TipoinversionDTO param);
		//public Task Actualizar(TipoinversionDTO param);
		//public Task Eliminar(int param);
	}
}
