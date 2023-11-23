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
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Services
{
	public class TipoInversionService : ITipoInversionService
	{
		private readonly ITipoInversionRepository _tipoinversionRepository;
		private readonly IMapper _mapper;

		public TipoInversionService(ITipoInversionRepository tipoinversionRepository, IMapper mapper ){
			_tipoinversionRepository = tipoinversionRepository;
			_mapper = mapper;
		}

		#region Methods

		/// <summary>
		/// Saves a record to the TipoInversion table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		//public async Task<int> Agregar(TipoinversionDTO param)
		//{
		//	var item = _mapper.Map<Tipoinversion>(param);
		//	return await _tipoinversionRepository.Agregar(item);
		//}

		/// <summary>
		/// Saves a record to the TipoInversion table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		//public async Task Actualizar(TipoinversionDTO param)
		//{
		//	var item = _mapper.Map<Tipoinversion>(param);
		//	await _tipoinversionRepository.Actualizar(item);
		//}

		/// <summary>
		/// Delete a record to the TipoInversion table.
		/// </summary>
		//public async Task Eliminar(int param)
		//{
		//	await _tipoinversionRepository.Eliminar(param);
		//}

		/// <summary>
		/// Selects the Single object of TipoInversion table.
		/// </summary>
		//public async Task<TipoinversionDTO> ObtenerPorClave(string param)
		//{
		//	var item = await _tipoinversionRepository.ObtenerPorClave(param);
		//	var result = _mapper.Map<TipoinversionDTO>(item);
		//	return result;
		//}

		///// <summary>
		///// Selects the Single object of TipoInversion table.
		///// </summary>
		//public async Task<TipoinversionDTO> ObtenerPorGuid(string guid)
		//{
		//	var item = await _tipoinversionRepository.ObtenerPorGuid(guid);
		//	var result = _mapper.Map<TipoinversionDTO>(item);
		//	return result;
		//}

		/// <summary>
		/// Selects the Single object of TipoInversion table.
		/// </summary>
		public async Task<List<TipoInversionDTO>> Listar()
		{
			var list = await _tipoinversionRepository.Listar();
			var result = _mapper.Map<List<TipoInversionDTO>>(list);
			return result;
		}


		#endregion
	}
}
