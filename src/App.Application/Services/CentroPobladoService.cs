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
	public class CentroPobladoService : ICentroPobladoService
	{
		private readonly ICentroPobladoRepository _centropobladoRepository;

		public CentroPobladoService(ICentroPobladoRepository centropobladoRepository ){
			_centropobladoRepository = centropobladoRepository;
		}

		#region Methods

		/// <summary>
		/// Saves a record to the CentroPoblado table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<int> Agregar(CentroPobladoDTO param)
		{
			return await _centropobladoRepository.Agregar(param);
		}

		/// <summary>
		/// Saves a record to the CentroPoblado table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task Actualizar(CentroPobladoDTO param)
		{
			await _centropobladoRepository.Actualizar(param);
		}

		/// <summary>
		/// Delete a record to the CentroPoblado table.
		/// </summary>
		public async Task Eliminar(int param)
		{
			await _centropobladoRepository.Eliminar(param);
		}

        public async Task<CentroPobladoListaDTO> Listar(int numeropagina, int cantfilas, string nombre, string ubigeoReniec, string ubigeoInei)
        {
            //await _centrosaludRepository.Listar();
            var list = await _centropobladoRepository.Listar(numeropagina, cantfilas, nombre,  ubigeoReniec,  ubigeoInei);
            //var result = _mapper.Map<List<DistritoDTO>>(list);
            return list;
        }


        #endregion
    }
}
