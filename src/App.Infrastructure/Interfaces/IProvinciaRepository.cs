using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Entities;

namespace App.Infrastructure.Interfaces
{
	public interface IProvinciaRepository 
	{
		public Task<Provincia> ObtenerPorClave(int param);
		//public Task<Provincia> ObtenerPorGuid(string guid);
		public Task<List<Provincia>> Listar(string codigoDepartamento);
		public Task<int> Agregar(Provincia param);
		public Task Actualizar(Provincia param);
		//public Task Eliminar(int param);
	}
}
