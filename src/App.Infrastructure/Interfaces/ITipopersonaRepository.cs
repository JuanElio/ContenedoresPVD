using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Entities;

namespace App.Infrastructure.Interfaces
{
	public interface ITipoPersonaRepository 
	{
		public Task<TipoPersona> ObtenerPorClave(string param);
		//public Task<TipoPersona> ObtenerPorGuid(string guid);
		public Task<List<TipoPersona>> Listar();
		public Task<string> Agregar(TipoPersona param);
		public Task Actualizar(TipoPersona param);
		//public Task Eliminar(int param);
	}
}
