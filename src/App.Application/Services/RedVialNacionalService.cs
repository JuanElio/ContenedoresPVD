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
	public class RedVialNacionalService : IRedVialNacionalService
	{
		private readonly IRedVialNacionalRepository _redvialnacionalRepository;
		private readonly IMapper _mapper;

		public RedVialNacionalService(IRedVialNacionalRepository redvialnacionalRepository, IMapper mapper ){
			_redvialnacionalRepository = redvialnacionalRepository;
			_mapper = mapper;
		}

		#region Methods

		/// <summary>
		/// Saves a record to the RedVialNacional table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<int> Agregar(RedVialNacionalDTO param)
		{
			var item = _mapper.Map<RedVialNacional>(param);
			return await _redvialnacionalRepository.Agregar(item);
		}

		/// <summary>
		/// Saves a record to the RedVialNacional table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task Actualizar(RedVialNacionalDTO param)
		{
			var item = _mapper.Map<RedVialNacional>(param);
			await _redvialnacionalRepository.Actualizar(item);
		}

        /// <summary>
        /// Delete a record to the RedVialNacional table.
        /// </summary>
        //public async Task Eliminar(int param)
        //{
        //	await _redvialnacionalRepository.Eliminar(param);
        //}

        //public async Task<List<RedVialNacionalDTO>> Listar(int numeropagina, int cantfilas, string ruta)
        //{
        //    var list = await _redvialnacionalRepository.Listar( numeropagina,  cantfilas,  ruta);
        //    var result = _mapper.Map<List<RedVialNacionalDTO>>(list);
        //    return result;
        //}

        public async Task<RedVialNacionalListasDTO> Listar(string ruta)
        {
            var list = await _redvialnacionalRepository.Listar(ruta);
            var result = _mapper.Map<RedVialNacionalListasDTO>(list);
            return result;
        }

        #endregion
    }
}
