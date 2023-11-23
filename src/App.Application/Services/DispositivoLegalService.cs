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
using App.Infrastructure.Repository;
using App.Domain.Entities;

namespace App.Application.Services
{
	public class DispositivoLegalService : IDispositivoLegalService
	{
		private readonly IDispositivoLegalRepository _dispositivolegalRepository;

		public DispositivoLegalService(IDispositivoLegalRepository dispositivolegalRepository ){
			_dispositivolegalRepository = dispositivolegalRepository;
		}

		#region Methods

		/// <summary>
		/// Saves a record to the DispositivoLegal table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<int> Agregar(DispositivoLegalAgregarDTO param)
		{
			return await _dispositivolegalRepository.Agregar(param);
		}

		/// <summary>
		/// Saves a record to the DispositivoLegal table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		//public async Task Actualizar(DispositivolegalDTO param)
		//{
		//	await _dispositivolegalRepository.Actualizar(param);
		//}

		/// <summary>
		/// Delete a record to the DispositivoLegal table.
		/// </summary>
		public async Task Eliminar(int param)
		{
			await _dispositivolegalRepository.Eliminar(param);
		}

		/// <summary>
		/// Selects the Single object of DispositivoLegal table.
		/// </summary>
		public async Task<DispositivoLegal> ObtenerPorClave(int param)
		{

			return await _dispositivolegalRepository.ObtenerPorClave(param);
		}

		/// <summary>
		/// Selects the Single object of DispositivoLegal table.
		/// </summary>
		//public async Task<DispositivolegalDTO> ObtenerPorGuid(string guid)
		//{
		//	 return await _dispositivolegalRepository.ObtenerPorGuid(guid);
		//}

		/// <summary>
		/// Selects the Single object of DispositivoLegal table.
		/// </summary>
		public async Task<List<DispositivoLegalDTO>> Listar()
		{
			 //return await _dispositivolegalRepository.Listar();
            var list = await _dispositivolegalRepository.Listar();
            //var result = _mapper.Map<List<DistritoDTO>>(list);
            return list;
        }


		#endregion
	}
}
