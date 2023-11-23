using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Entities;
using App.ModelDto.DTOs;

namespace App.Infrastructure.Interfaces
{
	public interface IRedVialNacionalRepository 
	{
		//public Task<RedVialNacional> ObtenerPorClave(int param);
		//public Task<RedVialNacional> ObtenerPorGuid(string guid);
		public Task<RedVialNacionalListasDTO> Listar( string ruta);
        //public Task<List<RedVialNacional>> Listar(string ruta);
        public Task<int> Agregar(RedVialNacional param);
		public Task Actualizar(RedVialNacional param);
		//public Task Eliminar(int param);
	}
}
