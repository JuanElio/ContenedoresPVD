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
	public class ProvinciaService : IProvinciaService
	{
		private readonly IProvinciaRepository _provinciaRepository;
		private readonly IMapper _mapper;

		public ProvinciaService(IProvinciaRepository provinciaRepository, IMapper mapper ){
			_provinciaRepository = provinciaRepository;
			_mapper = mapper;
		}

		#region Methods

		/// <summary>
		/// Saves a record to the Provincia table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<int> Agregar(ProvinciaDTO param)
		{
			var item = _mapper.Map<Provincia>(param);
			return await _provinciaRepository.Agregar(item);
		}

		/// <summary>
		/// Saves a record to the Provincia table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task Actualizar(ProvinciaDTO param)
		{
			var item = _mapper.Map<Provincia>(param);
			await _provinciaRepository.Actualizar(item);
		}

		/// <summary>
		/// Delete a record to the Provincia table.
		/// </summary>
		//public async Task Eliminar(int param)
		//{
		//	await _provinciaRepository.Eliminar(param);
		//}

		/// <summary>
		/// Selects the Single object of Provincia table.
		/// </summary>
		public async Task<ProvinciaDTO> ObtenerPorClave(int param)
		{
			var item = await _provinciaRepository.ObtenerPorClave(param);
			var result = _mapper.Map<ProvinciaDTO>(item);
			return result;
		}

		/// <summary>
		/// Selects the Single object of Provincia table.
		/// </summary>
		//public async Task<ProvinciaDTO> ObtenerPorGuid(string guid)
		//{
		//	var item = await _provinciaRepository.ObtenerPorGuid(guid);
		//	var result = _mapper.Map<ProvinciaDTO>(item);
		//	return result;
		//}

		/// <summary>
		/// Selects the Single object of Provincia table.
		/// </summary>
		public async Task<List<ProvinciaDTO>> Listar(string codigoDepartamento)
		{
			var list = await _provinciaRepository.Listar( codigoDepartamento);
			var result = _mapper.Map<List<ProvinciaDTO>>(list);
			return result;
		}


		#endregion
	}
}
