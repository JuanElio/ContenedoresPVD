using System.Collections.Generic;
using System.Threading.Tasks;
using App.ModelDto.DTOs;

namespace App.Infrastructure.Interfaces
{
	public interface ICalendarioRepository 
	{
		public Task<CalendarioDTO> ObtenerPorClave(string param);
		//public Task<CalendarioDTO> ObtenerPorGuid(string guid);
		public Task<List<CalendarioDTO>> ObtieneFechaFinal(string fechaInicio, int cantDias);
		//public Task<int> Agregar(CalendarioDTO param);
		public Task Actualizar(CalendarioActualizaDTO param);
		//public Task Eliminar(int param);
	}
}
