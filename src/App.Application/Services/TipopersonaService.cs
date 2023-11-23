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
	public class TipoPersonaService : ITipoPersonaService
	{
		private readonly ITipoPersonaRepository _tipopersonaRepository;
		private readonly IMapper _mapper;

		public TipoPersonaService(ITipoPersonaRepository tipopersonaRepository, IMapper mapper ){
			_tipopersonaRepository = tipopersonaRepository;
			_mapper = mapper;
		}

		#region Methods

		/// <summary>
		/// Saves a record to the TipoPersona table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<string> Agregar(TipoPersonaDTO param)
		{
			var item = _mapper.Map<TipoPersona>(param);
			return await _tipopersonaRepository.Agregar(item);
		}

		/// <summary>
		/// Saves a record to the TipoPersona table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task Actualizar(TipoPersonaDTO param)
		{
			var item = _mapper.Map<TipoPersona>(param);
			await _tipopersonaRepository.Actualizar(item);
		}

		/// <summary>
		/// Delete a record to the TipoPersona table.
		/// </summary>
		//public async Task Eliminar(int param)
		//{
		//	await _tipopersonaRepository.Eliminar(param);
		//}

		/// <summary>
		/// Selects the Single object of TipoPersona table.
		/// </summary>
		public async Task<TipoPersonaDTO> ObtenerPorClave(string param)
		{
			var item = await _tipopersonaRepository.ObtenerPorClave(param);
			var result = _mapper.Map<TipoPersonaDTO>(item);
			return result;
		}

		/// <summary>
		/// Selects the Single object of TipoPersona table.
		/// </summary>
		//public async Task<TipoPersonaDTO> ObtenerPorGuid(string guid)
		//{
		//	var item = await _tipopersonaRepository.ObtenerPorGuid(guid);
		//	var result = _mapper.Map<TipopersonaDTO>(item);
		//	return result;
		//}

		/// <summary>
		/// Selects the Single object of TipoPersona table.
		/// </summary>
		public async Task<List<TipoPersonaDTO>> Listar()
		{
			var list = await _tipopersonaRepository.Listar();
			var result = _mapper.Map<List<TipoPersonaDTO>>(list);
			return result;
		}


		#endregion
	}
}
