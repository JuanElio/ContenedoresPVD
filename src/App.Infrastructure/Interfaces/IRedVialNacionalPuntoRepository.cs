using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Entities;
using App.ModelDto.DTOs;

namespace App.Infrastructure.Interfaces
{
	public interface IRedVialNacionalPuntoRepository 
	{


        //public Task<RedVialNacionalPunto> ObtenerPorClave(int param);
        //public Task<RedVialNacionalPunto> ObtenerPorGuid(string guid);
        public Task<List<RedVialNacionalPunto>> Listar(string ruta);
        public Task<List<RedVialNacionalPunto>> Listar();
        public Task<int> Agregar(RedVialNacionalPunto param);
        public Task Actualizar(RedVialNacionalPunto param);
        //public Task Eliminar(int param);
    }
}
