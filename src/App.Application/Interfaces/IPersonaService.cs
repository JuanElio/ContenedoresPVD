using System.Collections.Generic;
using System.Threading.Tasks;
using App.ModelDto.DTOs;

namespace App.Application.Interfaces
{
	public interface IPersonaService 
	{
		//public Task<PersonaDTO> ObtenerPorClave(int param);
		//public Task<PersonaDTO> ObtenerPorGuid(string guid);
		public Task<PersonaListaDTO> Listar(int numeropagina, int cantfilas, string nombre, string codigoTipoIdentidad, string numeroDocumento);
		public Task<int> Agregar(PersonaDTO param);
		public Task Actualizar(PersonaDTO param);
		//public Task Eliminar(int param);
		public Task<PersonaDTO> ObtenerPorTipoNumero(string tipo, string numero);
		public Task<List<PersonaDTO>> ObtenerPorNombres(string nombre);

    }
}
