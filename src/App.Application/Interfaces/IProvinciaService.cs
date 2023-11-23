using System.Collections.Generic;
using System.Threading.Tasks;
using App.ModelDto.DTOs;

namespace App.Application.Interfaces
{
	public interface IProvinciaService 
	{
		public Task<ProvinciaDTO> ObtenerPorClave(int param);
		//public Task<ProvinciaDTO> ObtenerPorGuid(string guid);
		public Task<List<ProvinciaDTO>> Listar(string codigoDepartamento);
		public Task<int> Agregar(ProvinciaDTO param);
		public Task Actualizar(ProvinciaDTO param);
		//public Task Eliminar(int param);
	}
}
