using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Entities;

namespace App.Infrastructure.Interfaces
{
	public interface IDepartamentoRepository 
	{
		public Task<Departamento> ObtenerPorClave(int param);
		public Task<Departamento> ObtenerPorCodigo(string reniec, string inei);
        //public Task<Departamento> ObtenerPorGuid(string guid);
        public Task<List<Departamento>> Listar();
		public Task<int> Agregar(Departamento param);
		public Task Actualizar(Departamento param);
		//public Task Eliminar(int param);
	}
}
