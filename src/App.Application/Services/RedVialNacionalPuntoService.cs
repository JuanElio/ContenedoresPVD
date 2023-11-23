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
using App.Infrastructure.Repository;

namespace App.Application.Services
{
	public class RedVialNacionalPuntoService : IRedVialNacionalPuntoService
    {
		private readonly IRedVialNacionalPuntoRepository _redvialnacionalpuntoRepository;
		private readonly IMapper _mapper;

		public RedVialNacionalPuntoService(IRedVialNacionalPuntoRepository redvialnacionalpuntoRepository, IMapper mapper ){
			_redvialnacionalpuntoRepository = redvialnacionalpuntoRepository;
			_mapper = mapper;
		}

		#region Methods

		/// <summary>
		/// Saves a record to the RedVialNacionalPunto table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<int> Agregar(RedVialNacionalPuntoDTO param)
		{
			var item = _mapper.Map<RedVialNacionalPunto>(param);
			return await _redvialnacionalpuntoRepository.Agregar(item);
		}

		/// <summary>
		/// Saves a record to the RedVialNacionalPunto table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		//public async Task Actualizar(RedVialNacionalPuntoDTO param)
		//{
		//	var item = _mapper.Map<RedVialNacionalPuntoDTO>(param);
		//	await _redvialnacionalpuntoRepository.Actualizar(item);
		//}
		public async Task<List<RedVialNacionalPuntoDTO>> Listar()
		{
			var list = await _redvialnacionalpuntoRepository.Listar();
			var result = _mapper.Map<List<RedVialNacionalPuntoDTO>>(list);
			return result;
		}

        public async Task<List<RedVialNacionalPuntoDTO>> Listar(string ruta)
        {
            var list = await _redvialnacionalpuntoRepository.Listar(ruta);
            var result = _mapper.Map<List<RedVialNacionalPuntoDTO>>(list);
            return result;
        }

        /// <summary>
        /// Delete a record to the RedVialNacionalPunto table.
        /// </summary>
        //public async Task Eliminar(int param)
        //{
        //	await _redvialnacionalpuntoRepository.Eliminar(param);
        //}


        #endregion
    }
}
