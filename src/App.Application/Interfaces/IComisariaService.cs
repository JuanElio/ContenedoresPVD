using System.Collections.Generic;
using System.Threading.Tasks;
using App.ModelDto.DTOs;

namespace App.Application.Interfaces
{
	public interface IComisariaService 
	{
		//public Task<ComisariaDTO> ObtenerPorClave(int param);
		//public Task<ComisariaDTO> ObtenerPorGuid(string guid);
		public Task<ComisariaListaDTO> Listar(int numeropagina, int cantfilas, string nombre, string ubigeoReniec, string ubigeoInei);
		//public Task<int> Agregar(ComisariaDTO param);
		//public Task Actualizar(ComisariaDTO param);
		//public Task Eliminar(int param);
	}
}
