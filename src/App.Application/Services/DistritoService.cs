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
	public class DistritoService : IDistritoService
	{
		private readonly IDistritoRepository _distritoRepository;
		private readonly IMapper _mapper;

		public DistritoService(IDistritoRepository distritoRepository, IMapper mapper ){
			_distritoRepository = distritoRepository;
			_mapper = mapper;
		}

		#region Methods

		/// <summary>
		/// Saves a record to the Distrito table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<int> Agregar(DistritoDTO param)
		{
			var item = _mapper.Map<Distrito>(param);
			return await _distritoRepository.Agregar(item);
		}

		/// <summary>
		/// Saves a record to the Distrito table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task Actualizar(DistritoDTO param)
		{
			var item = _mapper.Map<Distrito>(param);
			await _distritoRepository.Actualizar(item);
		}

		/// <summary>
		/// Delete a record to the Distrito table.
		/// </summary>
		//public async Task Eliminar(int param)
		//{
		//	await _distritoRepository.Eliminar(param);
		//}

		/// <summary>
		/// Selects the Single object of Distrito table.
		/// </summary>
		public async Task<DistritoDTO> ObtenerPorClave(int param)
		{
			var item = await _distritoRepository.ObtenerPorClave(param);
			var result = _mapper.Map<DistritoDTO>(item);
			return result;
		}

		/// <summary>
		/// Selects the Single object of Distrito table.
		/// </summary>
		//public async Task<DistritoDTO> ObtenerPorGuid(string guid)
		//{
		//	var item = await _distritoRepository.ObtenerPorGuid(guid);
		//	var result = _mapper.Map<DistritoDTO>(item);
		//	return result;
		//}

		/// <summary>
		/// Selects the Single object of Distrito table.
		/// </summary>
		public async Task<List<DistritoDTO>> Listar(string codigoProvincia, string codigoProvinciaInei)
		{
			var list = await _distritoRepository.Listar( codigoProvincia,  codigoProvinciaInei);
			var result = _mapper.Map<List<DistritoDTO>>(list);
			return result;
		}


		#endregion
	}
}
