using System.Collections.Generic;
using System.Threading.Tasks;
using App.ModelDto.DTOs;

namespace App.Application.Interfaces
{
	public interface ITipoDocumentoIdentidadService 
	{
		public Task<TipoDocumentoIdentidadDTO> ObtenerPorClave(string param);
		//public Task<TipoDocumentoIdentidadDTO> ObtenerPorGuid(string guid);
		public Task<List<TipoDocumentoIdentidadDTO>> Listar();
		public Task<string> Agregar(TipoDocumentoIdentidadDTO param);
		public Task Actualizar(TipoDocumentoIdentidadDTO param);
		//public Task Eliminar(int param);
	}
}
