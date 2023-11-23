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
	public class ColegioService : IColegioService
	{
		private readonly IColegioRepository _colegioRepository;

		public ColegioService(IColegioRepository colegioRepository ){
			_colegioRepository = colegioRepository;
		}

        #region Methods

        /// <summary>
        /// Saves a record to the Colegio table.
        /// returns True if value saved successfullyelse false
        /// Throw exception with message value 'EXISTS' if the data is duplicate
        /// </summary>
        //public async Task<int> Agregar(ColegioDTO param)
        //{
        //	return await _colegioRepository.Agregar(param);
        //}

        ///// <summary>
        ///// Saves a record to the Colegio table.
        ///// returns True if value saved successfullyelse false
        ///// Throw exception with message value 'EXISTS' if the data is duplicate
        ///// </summary>
        //public async Task Actualizar(ColegioDTO param)
        //{
        //	await _colegioRepository.Actualizar(param);
        //}

        ///// <summary>
        ///// Delete a record to the Colegio table.
        ///// </summary>
        //public async Task Eliminar(int param)
        //{
        //	await _colegioRepository.Eliminar(param);
        //}

        public async Task<ColegioListaDTO> Listar(int numeropagina, int cantfilas, string nombre, string ubigeoReniec, string ubigeoInei)
        {
            //await _centrosaludRepository.Listar();
            var list = await _colegioRepository.Listar(numeropagina, cantfilas, nombre, ubigeoReniec, ubigeoInei);
            //var result = _mapper.Map<List<DistritoDTO>>(list);
            return list;
        }

        #endregion
    }
}
