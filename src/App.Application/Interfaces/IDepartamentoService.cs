using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Entities;
using App.ModelDto.DTOs;

namespace App.Application.Interfaces
{
	public interface IDepartamentoService 
	{
		public Task<DepartamentoDTO> ObtenerPorClave(int param);
		public Task<DepartamentoDTO> ObtenerPorCodigo(string reniec, string inei);
        //public Task<DepartamentoDTO> ObtenerPorGuid(string guid);
        public Task<List<DepartamentoDTO>> Listar();
		public Task<int> Agregar(DepartamentoDTO param);
		public Task Actualizar(DepartamentoDTO param);
		//public Task Eliminar(int param);
	}
}
