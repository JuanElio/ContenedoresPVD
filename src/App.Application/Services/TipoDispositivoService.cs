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
	public class TipoDispositivoService : ITipoDispositivoService
	{
		private readonly ITipoDispositivoRepository _tipodispositivoRepository;

		public TipoDispositivoService(ITipoDispositivoRepository tipodispositivoRepository ){
			_tipodispositivoRepository = tipodispositivoRepository;
		}

        #region Methods

        /// <summary>
        /// Saves a record to the TipoDispositivo table.
        /// returns True if value saved successfullyelse false
        /// Throw exception with message value 'EXISTS' if the data is duplicate
        /// </summary>
        //public async Task<int> Agregar(TipodispositivoDTO param)
        //{
        //	return await _tipodispositivoRepository.Agregar(param);
        //}

        /// <summary>
        /// Saves a record to the TipoDispositivo table.
        /// returns True if value saved successfullyelse false
        /// Throw exception with message value 'EXISTS' if the data is duplicate
        /// </summary>
        //public async Task Actualizar(TipodispositivoDTO param)
        //{
        //	await _tipodispositivoRepository.Actualizar(param);
        //}

        /// <summary>
        /// Delete a record to the TipoDispositivo table.
        /// </summary>
        //public async Task Eliminar(int param)
        //{
        //	await _tipodispositivoRepository.Eliminar(param);
        //}
        public async Task<List<TipoDispositivoDTO>> Listar()
        {
            var list = await _tipodispositivoRepository.Listar();
            //var result = _mapper.Map<List<TipoDispositivoDTO>>(list);
            return list;
        }

        #endregion
    }
}
