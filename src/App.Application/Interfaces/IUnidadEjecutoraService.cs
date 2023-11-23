using System.Collections.Generic;
using System.Threading.Tasks;
using App.ModelDto.DTOs;

namespace App.Application.Interfaces
{
	public interface IUnidadEjecutoraService 
	{
		public Task<UnidadEjecutoraDTO> ObtenerPorClave(int param);
		//public Task<UnidadEjecutoraDTO> ObtenerPorGuid(string guid);
		public Task<UnidadEjecutoraListaDTO> Listar(int numeropagina, int cantfilas, string nombre, string ubigeoReniec, string ubigeoInei);
		public Task<int> Agregar(UnidadEjecutoraDTO param);
		public Task Actualizar(UnidadEjecutoraDTO param);
		//public Task Eliminar(int param);
	}
}
