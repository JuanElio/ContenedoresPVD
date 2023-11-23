using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Entities;

namespace App.Infrastructure.Interfaces
{
	public interface ITipoDocumentoIdentidadRepository 
	{
		public Task<TipoDocumentoIdentidad> ObtenerPorClave(string param);
		//public Task<TipoDocumentoIdentidad> ObtenerPorGuid(string guid);
		public Task<List<TipoDocumentoIdentidad>> Listar();
		public Task<string> Agregar(TipoDocumentoIdentidad param);
		public Task Actualizar(TipoDocumentoIdentidad param);
		//public Task Eliminar(string param);
	}
}
