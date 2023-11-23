using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Entities;
using App.ModelDto.DTOs;

namespace App.Infrastructure.Interfaces
{
	public interface IUnidadEjecutoraRepository 
	{
		public Task<UnidadEjecutora> ObtenerPorClave(int param);
		//public Task<UnidadEjecutoraDTO> ObtenerPorGuid(string guid);
		public Task<UnidadEjecutoraListaDTO> Listar(int numeropagina, int cantfilas, string nombre, string ubigeoReniec, string ubigeoInei);
		public Task<int> Agregar(UnidadEjecutora param);
		public Task Actualizar(UnidadEjecutora param);
		//public Task Eliminar(int param);
	}
}
