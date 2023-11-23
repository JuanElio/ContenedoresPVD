using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Entities;

namespace App.Infrastructure.Interfaces
{
	public interface IDistritoRepository 
	{
		public Task<Distrito> ObtenerPorClave(int param);
		//public Task<Distrito> ObtenerPorGuid(string guid);
		public Task<List<Distrito>> Listar(string codigoProvincia, string codigoProvinciaInei);
		public Task<int> Agregar(Distrito param);
		public Task Actualizar(Distrito param);
		//public Task Eliminar(int param);
	}
}
