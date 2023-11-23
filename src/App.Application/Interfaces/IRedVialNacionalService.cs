using System.Collections.Generic;
using System.Threading.Tasks;
using App.ModelDto.DTOs;

namespace App.Application.Interfaces
{
	public interface IRedVialNacionalService 
	{
		//public Task<RedVialNacionalDTO> ObtenerPorClave(int param);
		//public Task<RedVialNacionalDTO> ObtenerPorGuid(string guid);
		//public Task<List<RedVialNacionalDTO>> Listar(int numeropagina, int cantfilas, string ruta);
        public Task<RedVialNacionalListasDTO> Listar(string ruta);
        public Task<int> Agregar(RedVialNacionalDTO param);
		public Task Actualizar(RedVialNacionalDTO param);
		//public Task Eliminar(int param);
	}
}
