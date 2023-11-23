using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using App.Application.Interfaces;
using App.Infrastructure.Interfaces;
using App.ModelDto.DTOs;

namespace App.Application.Services
{
	public class CalendarioService : ICalendarioService
	{
		private readonly ICalendarioRepository _calendarioRepository;

		public CalendarioService(ICalendarioRepository calendarioRepository ){
			_calendarioRepository = calendarioRepository;
		}

		#region Methods

		/// <summary>
		/// Saves a record to the Calendario table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		//public async Task<int> Agregar(CalendarioDTO param)
		//{
		//	return await _calendarioRepository.Agregar(param);
		//}

		/// <summary>
		/// Saves a record to the Calendario table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task Actualizar(CalendarioActualizaDTO param)
		{
			await _calendarioRepository.Actualizar(param);
		}

		/// <summary>
		/// Delete a record to the Calendario table.
		/// </summary>
		//public async Task Eliminar(int param)
		//{
		//	await _calendarioRepository.Eliminar(param);
		//}

		/// <summary>
		/// Selects the Single object of Calendario table.
		/// </summary>
		public async Task<CalendarioDTO> ObtenerPorClave(string param)
		{
			return await _calendarioRepository.ObtenerPorClave(param);
		}

		/// <summary>
		/// Selects the Single object of Calendario table.
		/// </summary>
		//public async Task<CalendarioDTO> ObtenerPorGuid(string guid)
		//{
		//	 return await _calendarioRepository.ObtenerPorGuid(guid);
		//}

		/// <summary>
		/// Selects the Single object of Calendario table.
		/// </summary>
		public async Task<List<CalendarioDTO>> ObtieneFechaFinal(string fechaInicio, int cantDias)
        {
			 return await _calendarioRepository.ObtieneFechaFinal( fechaInicio,  cantDias);
		}


		#endregion
	}
}
