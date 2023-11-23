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
	public class UnidadEjecutoraService : IUnidadEjecutoraService
	{
		private readonly IUnidadEjecutoraRepository _unidadejecutoraRepository;
		private readonly IMapper _mapper;

		public UnidadEjecutoraService(IUnidadEjecutoraRepository unidadejecutoraRepository, IMapper mapper ){
			_unidadejecutoraRepository = unidadejecutoraRepository;
			_mapper = mapper;
		}

		#region Methods

		/// <summary>
		/// Saves a record to the UnidadEjecutora table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<int> Agregar(UnidadEjecutoraDTO param)
		{
			var item = _mapper.Map<UnidadEjecutora>(param);
			return await _unidadejecutoraRepository.Agregar(item);
		}

		/// <summary>
		/// Saves a record to the UnidadEjecutora table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task Actualizar(UnidadEjecutoraDTO param)
		{
			var item = _mapper.Map<UnidadEjecutora>(param);
			await _unidadejecutoraRepository.Actualizar(item);
		}

		/// <summary>
		/// Delete a record to the UnidadEjecutora table.
		/// </summary>
		//public async Task Eliminar(int param)
		//{
		//	await _unidadejecutoraRepository.Eliminar(param);
		//}

		/// <summary>
		/// Selects the Single object of UnidadEjecutora table.
		/// </summary>
		public async Task<UnidadEjecutoraDTO> ObtenerPorClave(int param)
		{
			var item = await _unidadejecutoraRepository.ObtenerPorClave(param);
			var result = _mapper.Map<UnidadEjecutoraDTO>(item);
			return result;
		}

		/// <summary>
		/// Selects the Single object of UnidadEjecutora table.
		/// </summary>
		//public async Task<UnidadEjecutoraDTO> ObtenerPorGuid(string guid)
		//{
		//	var item = await _unidadejecutoraRepository.ObtenerPorGuid(guid);
		//	var result = _mapper.Map<UnidadejecutoraDTO>(item);
		//	return result;
		//}

		/// <summary>
		/// Selects the Single object of UnidadEjecutora table.
		/// </summary>
		public async Task<UnidadEjecutoraListaDTO> Listar(int numeropagina, int cantfilas, string nombre, string ubigeoReniec, string ubigeoInei)
		{
			var list = await _unidadejecutoraRepository.Listar( numeropagina,  cantfilas,  nombre,  ubigeoReniec,  ubigeoInei);
			//var result = _mapper.Map<List<UnidadEjecutoraDTO>>(list);
			return list;
		}


		#endregion
	}
}
