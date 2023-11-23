using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Entities;

namespace App.Infrastructure.Interfaces
{
	public interface ITipoInversionRepository 
	{
		//public Task<Tipoinversion> ObtenerPorClave(int param);
		//public Task<Tipoinversion> ObtenerPorGuid(string guid);
		public Task<List<TipoInversion>> Listar();
		//public Task<int> Agregar(Tipoinversion param);
		//public Task Actualizar(Tipoinversion param);
		//public Task Eliminar(int param);
	}
}
