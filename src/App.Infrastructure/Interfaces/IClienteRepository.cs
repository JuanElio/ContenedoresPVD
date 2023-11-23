using App.Domain.Entities;

namespace App.Infrastructure.Interfaces
{
    public interface IClienteRepository 
	{
		public Task<Cliente> ObtenerPorClave(int param);
		public Task<Cliente> ObtenerPorGuid(string guid);
		public Task<List<Cliente>> Listar();
		public Task<int> Agregar(Cliente param);
		public Task Actualizar(Cliente param);
		//public Task Eliminar(id param);
	}
}
