using System.Collections.Generic;
using System.Threading.Tasks;
using App.ModelDto.DTOs;

namespace App.Application.Interfaces
{
	public interface IDistritoService 
	{
		public Task<DistritoDTO> ObtenerPorClave(int param);
		//public Task<DistritoDTO> ObtenerPorGuid(string guid);
		public Task<List<DistritoDTO>> Listar(string codigoProvincia, string codigoProvinciaInei);
		public Task<int> Agregar(DistritoDTO param);
		public Task Actualizar(DistritoDTO param);
		//public Task Eliminar(int param);
	}
}
