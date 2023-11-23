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
	public class ProveedorService : IProveedorService
	{
		private readonly IProveedorRepository _proveedorRepository;
		private readonly IMapper _mapper;

		public ProveedorService(IProveedorRepository proveedorRepository, IMapper mapper ){
			_proveedorRepository = proveedorRepository;
			_mapper = mapper;
		}

		#region Methods

		/// <summary>
		/// Saves a record to the PROVEEDOR table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<int> Agregar(ProveedorDTO param)
		{
			var item = _mapper.Map<Proveedor>(param);
			return await _proveedorRepository.Agregar(item);
		}

		/// <summary>
		/// Saves a record to the PROVEEDOR table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task Actualizar(ProveedorDTO param)
		{
			var item = _mapper.Map<Proveedor>(param);
			await _proveedorRepository.Actualizar(item);
		}

		/// <summary>
		/// Selects the Single object of PROVEEDOR table.
		/// </summary>
		public async Task<ProveedorDTO> ObtenerPorClave(int param)
		{
			var item = await _proveedorRepository.ObtenerPorClave(param);
			var result = _mapper.Map<ProveedorDTO>(item);
			return result;
		}

		/// <summary>
		/// Selects the Single object of PROVEEDOR table.
		/// </summary>
		public async Task<ProveedorDTO> ObtenerPorGuid(string guid)
		{
			var item = await _proveedorRepository.ObtenerPorGuid(guid);
			var result = _mapper.Map<ProveedorDTO>(item);
			return result;
		}

		/// <summary>
		/// Selects the Single object of PROVEEDOR table.
		/// </summary>
		public async Task<List<ProveedorDTO>> Listar()
		{
			var list = await _proveedorRepository.Listar();
			var result = _mapper.Map<List<ProveedorDTO>>(list);
			return result;
		}

        /// <summary>
        /// Selects the Single object of PROVEEDOR table.
        /// </summary>
        public async Task Eliminar(int id)
        {
			await _proveedorRepository.Eliminar(id);
        }

        #endregion
    }
}
