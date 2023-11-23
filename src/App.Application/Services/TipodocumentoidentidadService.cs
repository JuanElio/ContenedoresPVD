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
	public class TipoDocumentoIdentidadService : ITipoDocumentoIdentidadService
	{
		private readonly ITipoDocumentoIdentidadRepository _tipodocumentoidentidadRepository;
		private readonly IMapper _mapper;

		public TipoDocumentoIdentidadService(ITipoDocumentoIdentidadRepository tipodocumentoidentidadRepository, IMapper mapper ){
			_tipodocumentoidentidadRepository = tipodocumentoidentidadRepository;
			_mapper = mapper;
		}

		#region Methods

		/// <summary>
		/// Saves a record to the TipoDocumentoIdentidad table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<string> Agregar(TipoDocumentoIdentidadDTO param)
		{
			var item = _mapper.Map<TipoDocumentoIdentidad>(param);
			return await _tipodocumentoidentidadRepository.Agregar(item);
		}

		/// <summary>
		/// Saves a record to the TipoDocumentoIdentidad table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task Actualizar(TipoDocumentoIdentidadDTO param)
		{
			var item = _mapper.Map<TipoDocumentoIdentidad>(param);
			await _tipodocumentoidentidadRepository.Actualizar(item);
		}

		/// <summary>
		/// Delete a record to the TipoDocumentoIdentidad table.
		/// </summary>
		//public async Task Eliminar(string param)
		//{
		//	await _tipodocumentoidentidadRepository.Eliminar(param);
		//}

		/// <summary>
		/// Selects the Single object of TipoDocumentoIdentidad table.
		/// </summary>
		public async Task<TipoDocumentoIdentidadDTO> ObtenerPorClave(string param)
		{
			var item = await _tipodocumentoidentidadRepository.ObtenerPorClave(param);
			var result = _mapper.Map<TipoDocumentoIdentidadDTO>(item);
			return result;
		}

		/// <summary>
		/// Selects the Single object of TipoDocumentoIdentidad table.
		/// </summary>
		//public async Task<TipoDocumentoIdentidadDTO> ObtenerPorGuid(string guid)
		//{
		//	var item = await _tipodocumentoidentidadRepository.ObtenerPorGuid(guid);
		//	var result = _mapper.Map<TipodocumentoidentidadDTO>(item);
		//	return result;
		//}

		/// <summary>
		/// Selects the Single object of TipoDocumentoIdentidad table.
		/// </summary>
		public async Task<List<TipoDocumentoIdentidadDTO>> Listar()
		{
			var list = await _tipodocumentoidentidadRepository.Listar();
			var result = _mapper.Map<List<TipoDocumentoIdentidadDTO>>(list);
			return result;
		}


		#endregion
	}
}
