using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Entities;

namespace App.Infrastructure.Interfaces
{
	public interface IProveedorRepository 
	{
		public Task<Proveedor> ObtenerPorClave(int param);
		public Task<Proveedor> ObtenerPorGuid(string guid);
		public Task<List<Proveedor>> Listar();
		public Task<int> Agregar(Proveedor param);
		public Task Actualizar(Proveedor param);
		public Task Eliminar(int param);
	}
}
