using System.Collections.Generic;
using System.Threading.Tasks;
using App.ModelDto.DTOs;

namespace App.Infrastructure.Interfaces
{
	public interface ICentroPobladoRepository 
	{
		//public Task<CentroPobladoDTO> ObtenerPorClave(int param);
		//public Task<CentroPobladoDTO> ObtenerPorGuid(string guid); 
		public Task<CentroPobladoListaDTO> Listar(int numeropagina, int cantfilas, string nombre, string ubigeoReniec, string ubigeoInei);
		public Task<int> Agregar(CentroPobladoDTO param);
		public Task Actualizar(CentroPobladoDTO param);
		public Task Eliminar(int param);
	}
}
