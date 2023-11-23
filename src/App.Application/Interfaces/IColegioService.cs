using System.Collections.Generic;
using System.Threading.Tasks;
using App.ModelDto.DTOs;

namespace App.Application.Interfaces
{
	public interface IColegioService 
	{
		//public Task<ColegioDTO> ObtenerPorClave(int param);
		//public Task<ColegioDTO> ObtenerPorGuid(string guid);
		public Task<ColegioListaDTO> Listar(int numeropagina, int cantfilas, string nombre, string ubigeoReniec, string ubigeoInei);
		//public Task<int> Agregar(ColegioDTO param);
		//public Task Actualizar(ColegioDTO param);
		//public Task Eliminar(int param);
	}
}
