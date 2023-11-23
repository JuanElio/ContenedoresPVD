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

namespace App.Application.Services
{
	public class CentroSaludService : ICentroSaludService
	{
		private readonly ICentroSaludRepository _centrosaludRepository;

		public CentroSaludService(ICentroSaludRepository centrosaludRepository ){
			_centrosaludRepository = centrosaludRepository;
		}

		#region Methods

		/// <summary>
		/// Saves a record to the CentroSalud table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<int> Agregar(CentroSaludDTO param)
		{
			return await _centrosaludRepository.Agregar(param);
		}

		/// <summary>
		/// Saves a record to the CentroSalud table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task Actualizar(CentroSaludDTO param)
		{
			await _centrosaludRepository.Actualizar(param);
		}

		/// <summary>
		/// Delete a record to the CentroSalud table.
		/// </summary>
		public async Task Eliminar(int param)
		{
			await _centrosaludRepository.Eliminar(param);
		}

        public async Task<CentroSaludListaDTO> Listar(int numeropagina, int cantfilas, string nombre, string ubigeoReniec, string ubigeoInei)
        {
            //await _centrosaludRepository.Listar();
            var list = await _centrosaludRepository.Listar( numeropagina,  cantfilas, nombre, ubigeoReniec,  ubigeoInei);
            //var result = _mapper.Map<List<DistritoDTO>>(list);
            return list;
        }


        #endregion
    }
}
