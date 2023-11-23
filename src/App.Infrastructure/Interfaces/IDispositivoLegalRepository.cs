using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Entities;
using App.ModelDto.DTOs;

namespace App.Infrastructure.Interfaces
{
	public interface IDispositivoLegalRepository 
	{
		public Task<DispositivoLegal> ObtenerPorClave(int param);
		//public Task<DispositivolegalDTO> ObtenerPorGuid(string guid);
		public Task<List<DispositivoLegalDTO>> Listar();
		public Task<int> Agregar(DispositivoLegalAgregarDTO param);
		//public Task Actualizar(DispositivolegalDTO param);
		public Task Eliminar(int param);
	}
}
