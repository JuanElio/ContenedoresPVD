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
	public class DepartamentoService : IDepartamentoService
	{
		private readonly IDepartamentoRepository _departamentoRepository;
		private readonly IMapper _mapper;

		public DepartamentoService(IDepartamentoRepository departamentoRepository, IMapper mapper ){
			_departamentoRepository = departamentoRepository;
			_mapper = mapper;
		}

		#region Methods

		/// <summary>
		/// Saves a record to the Departamento table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<int> Agregar(DepartamentoDTO param)
		{
			var item = _mapper.Map<Departamento>(param);
			return await _departamentoRepository.Agregar(item);
		}

		/// <summary>
		/// Saves a record to the Departamento table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task Actualizar(DepartamentoDTO param)
		{
			var item = _mapper.Map<Departamento>(param);
			await _departamentoRepository.Actualizar(item);
		}

		/// <summary>
		/// Delete a record to the Departamento table.
		/// </summary>
		//public async Task Eliminar(int param)
		//{
		//	await _departamentoRepository.Eliminar(param);
		//}

		/// <summary>
		/// Selects the Single object of Departamento table.
		/// </summary>
		public async Task<DepartamentoDTO> ObtenerPorClave(int param)
		{
			var item = await _departamentoRepository.ObtenerPorClave(param);
			var result = _mapper.Map<DepartamentoDTO>(item);
			return result;
		}

        public async Task<DepartamentoDTO> ObtenerPorCodigo(string reniec, string inei)
        {
            var item = await _departamentoRepository.ObtenerPorCodigo(reniec,  inei);
            var result = _mapper.Map<DepartamentoDTO>(item);
            return result;
        }

       

        /// <summary>
        /// Selects the Single object of Departamento table.
        /// </summary>
        //public async Task<DepartamentoDTO> ObtenerPorGuid(string guid)
        //{
        //	var item = await _departamentoRepository.ObtenerPorGuid(guid);
        //	var result = _mapper.Map<DepartamentoDTO>(item);
        //	return result;
        //}

        /// <summary>
        /// Selects the Single object of Departamento table.
        /// </summary>
        public async Task<List<DepartamentoDTO>> Listar()
		{
			var list = await _departamentoRepository.Listar();
			var result = _mapper.Map<List<DepartamentoDTO>>(list);
			return result;
		}


		#endregion
	}
}
