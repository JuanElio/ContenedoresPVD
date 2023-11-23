using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Entities;
using App.ModelDto.DTOs;

namespace App.Infrastructure.Interfaces
{
	public interface IPersonaRepository 
	{
		//public Task<Persona> ObtenerPorClave(int param);
		//public Task<Persona> ObtenerPorGuid(string guid);
		public Task<PersonaListaDTO> Listar(int numeropagina, int cantfilas, string nombre, string codigoTipoIdentidad, string numeroDocumento);
		public Task<int> Agregar(Persona param);
		public Task Actualizar(Persona param);
		//public Task Eliminar(int param);
		public Task<Persona> ObtenerPorTipoNumero(string tipo, string numero);
		public Task<List<Persona>> ObtenerPorNombres(string nombre);

    }
}
