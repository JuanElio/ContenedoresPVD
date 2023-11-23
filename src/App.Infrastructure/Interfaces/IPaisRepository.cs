using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Entities;

namespace App.Infrastructure.Interfaces
{
	public interface IPaisRepository 
	{
        public Task<List<Pais>> Listar();
        public Task<Pais> ObtenerPorCodigo(string codigo);
  //      public Task<Pais> ObtenerPorClave(int param);
  //public Task<Pais> ObtenerPorGuid(string guid);

        //public Task<int> Agregar(Pais param);
        //public Task Actualizar(Pais param);
        //public Task Eliminar(int param);
    }
}
