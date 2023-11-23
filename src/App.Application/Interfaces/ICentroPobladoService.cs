using System.Collections.Generic;
using System.Threading.Tasks;
using App.ModelDto.DTOs;

namespace App.Application.Interfaces
{
	public interface ICentroPobladoService 
	{
		//public Task<CentropobladoDTO> ObtenerPorClave(int param);
		//public Task<CentropobladoDTO> ObtenerPorGuid(string guid);
		public Task<CentroPobladoListaDTO> Listar(int numeropagina, int cantfilas, string nombre, string ubigeoReniec, string ubigeoInei);
		public Task<int> Agregar(CentroPobladoDTO param);
		public Task Actualizar(CentroPobladoDTO param);
		public Task Eliminar(int param);
	}
}
