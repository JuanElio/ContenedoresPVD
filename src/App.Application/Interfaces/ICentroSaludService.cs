using System.Collections.Generic;
using System.Threading.Tasks;
using App.ModelDto.DTOs;

namespace App.Application.Interfaces
{
	public interface ICentroSaludService 
	{
		//public Task<CentroSaludDTO> ObtenerPorClave(int param);
		//public Task<CentroSaludDTO> ObtenerPorGuid(string guid);
		public Task<CentroSaludListaDTO> Listar(int numeropagina, int cantfilas, string nombre, string ubigeoReniec, string ubigeoInei);
		public Task<int> Agregar(CentroSaludDTO param);
		public Task Actualizar(CentroSaludDTO param);
		public Task Eliminar(int param);
	}
}
