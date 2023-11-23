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
	public class PaisService : IPaisService
	{
		private readonly IPaisRepository _paisRepository;
		private readonly IMapper _mapper;

		public PaisService(IPaisRepository paisRepository, IMapper mapper ){
			_paisRepository = paisRepository;
			_mapper = mapper;
		}

        #region Methods

        /// <summary>
        /// Saves a record to the Pais table.
        /// returns True if value saved successfullyelse false
        /// Throw exception with message value 'EXISTS' if the data is duplicate
        /// </summary>
        //public async Task<int> Agregar(PaisDTO param)
        //{
        //	var item = _mapper.Map<Pais>(param);
        //	return await _paisRepository.Agregar(item);
        //}

        /// <summary>
        /// Saves a record to the Pais table.
        /// returns True if value saved successfullyelse false
        /// Throw exception with message value 'EXISTS' if the data is duplicate
        /// </summary>
        //public async Task Actualizar(PaisDTO param)
        //{
        //	var item = _mapper.Map<Pais>(param);
        //	await _paisRepository.Actualizar(item);
        //}

        ///// <summary>
        ///// Delete a record to the Pais table.
        ///// </summary>
        //public async Task Eliminar(int param)
        //{
        //	await _paisRepository.Eliminar(param);
        //}

        ///// <summary>
        ///// Selects the Single object of Pais table.
        ///// </summary>
        //public async Task<PaisDTO> ObtenerPorClave(int param)
        //{
        //	var item = await _paisRepository.ObtenerPorClave(param);
        //	var result = _mapper.Map<PaisDTO>(item);
        //	return result;
        //}

        /// <summary>
        /// Selects the Single object of Pais table.
        /// </summary>
        //public async Task<PaisDTO> ObtenerPorGuid(string guid)
        //{
        //	var item = await _paisRepository.ObtenerPorGuid(guid);
        //	var result = _mapper.Map<PaisDTO>(item);
        //	return result;
        //}
        public async Task<PaisDTO> ObtenerPorCodigo(string codigo)
        {
            var item = await _paisRepository.ObtenerPorCodigo(codigo);
            var result = _mapper.Map<PaisDTO>(item);
            return result;
        }
        
        /// <summary>
        /// Selects the Single object of Pais table.
        /// </summary>
        public async Task<List<PaisDTO>> Listar()
		{
			var list = await _paisRepository.Listar();
			var result = _mapper.Map<List<PaisDTO>>(list);
			return result;
		}


		#endregion
	}
}
