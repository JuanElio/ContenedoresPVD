using System.Collections.Generic;
using System.Threading.Tasks;
using App.ModelDto.DTOs;

namespace App.Application.Interfaces
{
	public interface IProveedorService 
	{
		public Task<ProveedorDTO> ObtenerPorClave(int param);
		public Task<ProveedorDTO> ObtenerPorGuid(string guid);
		public Task<List<ProveedorDTO>> Listar();
		public Task<int> Agregar(ProveedorDTO param);
		public Task Actualizar(ProveedorDTO param);
		public Task Eliminar(int param);
	}
}
