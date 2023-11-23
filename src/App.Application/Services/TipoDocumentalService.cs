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
	public class TipoDocumentalService : ITipoDocumentalService
	{
		private readonly ITipoDocumentalRepository _tipodocumentalRepository;

		public TipoDocumentalService(ITipoDocumentalRepository tipodocumentalRepository ){
			_tipodocumentalRepository = tipodocumentalRepository;
		}

		#region Methods

		/// <summary>
		/// Saves a record to the TipoDocumental table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		//public async Task<int> Agregar(TipodocumentalDTO param)
		//{
		//	return await _tipodocumentalRepository.Agregar(param);
		//}

		/// <summary>
		/// Saves a record to the TipoDocumental table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		//public async Task Actualizar(TipodocumentalDTO param)
		//{
		//	await _tipodocumentalRepository.Actualizar(param);
		//}

		/// <summary>
		/// Delete a record to the TipoDocumental table.
		/// </summary>
		//public async Task Eliminar(int param)
		//{
		//	await _tipodocumentalRepository.Eliminar(param);
		//}

		/// <summary>
		/// Selects the Single object of TipoDocumental table.
		/// </summary>
		//public async Task<TipodocumentalDTO> ObtenerPorClave(int param)
		//{
		//	 return await _tipodocumentalRepository.ObtenerPorClave(param);
		//}

		/// <summary>
		/// Selects the Single object of TipoDocumental table.
		/// </summary>
		//public async Task<TipodocumentalDTO> ObtenerPorGuid(string guid)
		//{
		//	 return await _tipodocumentalRepository.ObtenerPorGuid(guid);
		//}

		/// <summary>
		/// Selects the Single object of TipoDocumental table.
		/// </summary>
		public async Task<List<TipoDocumentalDTO>> Listar()
		{
			 return await _tipodocumentalRepository.Listar();
		}


		#endregion
	}
}
