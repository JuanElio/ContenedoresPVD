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
	public class ComisariaService : IComisariaService
	{
		private readonly IComisariaRepository _comisariaRepository;

		public ComisariaService(IComisariaRepository comisariaRepository ){
			_comisariaRepository = comisariaRepository;
		}

        #region Methods

        /// <summary>
        /// Saves a record to the Comisaria table.
        /// returns True if value saved successfullyelse false
        /// Throw exception with message value 'EXISTS' if the data is duplicate
        /// </summary>
        //public async Task<int> Agregar(ComisariaDTO param)
        //{
        //	return await _comisariaRepository.Agregar(param);
        //}

        ///// <summary>
        ///// Saves a record to the Comisaria table.
        ///// returns True if value saved successfullyelse false
        ///// Throw exception with message value 'EXISTS' if the data is duplicate
        ///// </summary>
        //public async Task Actualizar(ComisariaDTO param)
        //{
        //	await _comisariaRepository.Actualizar(param);
        //}

        ///// <summary>
        ///// Delete a record to the Comisaria table.
        ///// </summary>
        //public async Task Eliminar(int param)
        //{
        //	await _comisariaRepository.Eliminar(param);
        //}

        public async Task<ComisariaListaDTO> Listar(int numeropagina, int cantfilas, string nombre, string ubigeoReniec, string ubigeoInei)
        {
            //await _centrosaludRepository.Listar();
            var list = await _comisariaRepository.Listar(numeropagina, cantfilas, nombre, ubigeoReniec, ubigeoInei);
            //var result = _mapper.Map<List<DistritoDTO>>(list);
            return list;
        }
        #endregion
    }
}
